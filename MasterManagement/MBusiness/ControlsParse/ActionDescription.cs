using MEventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MBusiness.ControlsParse
{
    /*
     * time:    2020/09/19
     * content: 实现为每个执行的control自动设置TaskPromise
     * Reviser: ymz
     */

    internal class ActionDescription
    {
        internal ActionDescription(ControlDescription control, Dictionary<string, object> pars)
        {
            if (control == null)
                return;

            this.Controler = control;
            this.ParseActionMetdate(pars);
        }


        /// <summary>
        /// 表示当前Control
        /// </summary>
        internal ControlDescription Controler { get; private set; }
        /// <summary>
        /// 当前需要执行的action
        /// </summary>
        internal MethodInfo Action { get; private set; }
        /// <summary>
        /// action需要的参数
        /// </summary>
        internal List<KeyValuePair<string, object>> Parms { get; private set; }



        private void ParseActionMetdate(Dictionary<string, object> pars)
        {
            if (!pars.ContainsKey("action") || pars["action"] == null)
                throw new Exception("未指定action");


            this.Action = this.GetActionMethod(this.Controler.ControlType, pars["action"].ToString());
            this.Parms = this.GetParameter(this.Action, pars);
        }

        private MethodInfo GetActionMethod(Type type,string action)
        {
            return type.GetMethod(action, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance) ??
                        throw new Exception("Not found the action");
        }
        //整理执行Action时需要的参数
        private List<KeyValuePair<string, object>> GetParameter(MethodInfo action, Dictionary<string, object> pars)
        {
            if (action == null)
                return null;

            List<KeyValuePair<string, object>> parMapp = null;
            ParameterInfo[] prames = null;

            prames = action.GetParameters();
            if (prames == null || prames.Length <= 0)
                return parMapp;

            parMapp = new List<KeyValuePair<string, object>>();
            foreach (ParameterInfo p in prames)//按顺序整理参数
            {
                if (!pars.ContainsKey(p.Name) && //未提供参数，且也不能用null代替参数时
                    p.ParameterType.IsValueType &&
                    p.ParameterType.IsGenericType &&
                    p.ParameterType.GetGenericTypeDefinition() != typeof(Nullable<>))
                {
                    throw new Exception($"不可为null参数\"{p.Name}\"未赋值。");
                }
                else if (!pars.ContainsKey(p.Name))
                {
                    parMapp.Add(new KeyValuePair<string, object>(p.Name, null));//null代替没有的默认参数
                }
                parMapp.Add(new KeyValuePair<string, object>(p.Name, pars[p.Name]));
            }
            return parMapp;
        }
        //为当前control设置TaskPromise
        private void SetTaskPromiseToControl(object control, TaskPromise promise)
        {
            Type ctl = control.GetType();
            var pro = ctl.GetProperty("Promise", BindingFlags.NonPublic | BindingFlags.Instance);
            if (pro != null)
            {
                pro.SetValue(control, promise);
            }
        }


        
        //整理method的返回值为Task<T>的情况
        private TaskWrapper GetGenericDefaultTaskPromise(MethodInfo action,object inst, params object[] methodArgs)
        {
            if (!action.ReturnType.IsGenericType || action.ReturnType.GetGenericTypeDefinition() != typeof(Task<>))
                return null;
            
            Type promise = typeof(DefaultResultTaskPromise<>);
            promise = promise.MakeGenericType(typeof(object));               //构造封闭泛型类型

            Task<object> wrapper = new Task<object>(() =>
            {
                object task = action.Invoke(this.Controler.GetControlInst(), methodArgs);
                Type taskType = task.GetType();
                return taskType.GetProperty("Result", BindingFlags.Public | BindingFlags.Instance).GetValue(task);
            });

            return new TaskWrapper()
            {
                Result = (TaskPromise)Activator.CreateInstance(promise, wrapper),
                Action = () => wrapper.Start()
            };
        }
        //整理method的返回值为Taskd的情况
        private TaskWrapper GetDefaultTaskPromise(MethodInfo method, object inst, params object[] methodArgs)
        {
            if (method.ReturnType != typeof(Task))
                return null;

            Task obj = new Task(() => ((Task)method.Invoke(inst, methodArgs)).Wait());
            return new TaskWrapper()
            {
                Result = new DefaultTaskPromise(obj),
                Action = () => obj.Start()
            };
        }
        //包装method的返回值
        private TaskWrapper GetResultTaskPromise(MethodInfo method, object inst, params object[] methodArgs)
        {
            Task<object> task = new Task<object>(() =>
            {
                return method.Invoke(inst, methodArgs);
            });

            return new TaskWrapper()
            {
                Result = new DefaultResultTaskPromise<object>(task),
                Action = () => task.Start()
            };
        }
        //包装一个无返回值得method
        private TaskWrapper GetNoneTaskPromise(MethodInfo method, object inst, params object[] methodArgs)
        {
            Task t = new Task(() => { method.Invoke(inst, methodArgs); });
            return new TaskWrapper() {
                Result = new DefaultTaskPromise(t),
                Action = () => t.Start()
            };
        }



        private TaskPromise ExcuteCore()
        {
            TaskWrapper wrapper = null;
            MethodInfo action = this.Action;
            Object control = this.Controler.GetControlInst();
            Object[] parms = this.Parms?.Select(k => k.Value).ToArray();

            if (this.Action.ReturnType == null)//不存在返回类型的action
            {
                wrapper = this.GetNoneTaskPromise(action, control, parms);
            }
            else if (this.Action.ReturnType.IsGenericType && this.Action.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))//存在返回类型为Task<T>的action
            {
                wrapper = this.GetGenericDefaultTaskPromise(action, control, parms);
            }
            else if (this.Action.ReturnType == typeof(Task))//存在返回类型为Task的action
            {
                wrapper = this.GetDefaultTaskPromise(action, control, parms);
            }
            else //存在一个正常的返回值的action
            {
                wrapper = this.GetResultTaskPromise(action, control, parms);
            }

            this.SetTaskPromiseToControl(control, wrapper.Result);

            //执行
            wrapper.Action();
            return wrapper.Result;
        }


        /// <summary>
        /// 返回当前执行的任务
        /// </summary>
        /// <returns></returns>
        internal TaskPromise Execute()
        {
            return this.ExcuteCore();
        }


        private class TaskWrapper
        {
            internal TaskPromise Result { get; set; }
            internal Action Action { get; set; }
        }
    }
}
