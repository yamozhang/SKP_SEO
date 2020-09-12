using MEventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MBusiness.ControlsParse
{
    internal class ActionDescription
    {
        internal ActionDescription(ControlDescription control, Dictionary<string, object> pars)
        {
            if (control == null)
                return;

            this.Controler = control;
            this.Builder(pars);
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



        private void Builder(Dictionary<string, object> pars)
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
        //整理需要的参数
        private List<KeyValuePair<string, object>> GetParameter(MethodInfo method, Dictionary<string, object> pars)
        {
            if (method == null)
                return null;

            List<KeyValuePair<string, object>> parMapp = null;
            ParameterInfo[] prames = null;

            prames = method.GetParameters();
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
        //整理method的返回值为Task<T>的情况
        private TaskPromise GetGenericDefaultTaskPromise(MethodInfo method,object inst, params object[] methodArgs)
        {
            if (!method.ReturnType.IsGenericType || method.ReturnType.GetGenericTypeDefinition() != typeof(Task<>))
                return null;

            Type[] returnType = method.ReturnType.GetGenericArguments();//泛型参数类型
            Type generiTaskPromise = typeof(DefaultResultTaskPromise<>);
            generiTaskPromise = generiTaskPromise.MakeGenericType(returnType[0]);//构造封闭泛型类型
            object obj = method.Invoke(this.Controler.GetControlInst(), methodArgs);//执行action返回 Task<T>

            return (TaskPromise)Activator.CreateInstance(generiTaskPromise, obj);//实例化DefaultResultTaskPromise<T>
        }
        //整理method的返回值为Taskd的情况
        private TaskPromise GetDefaultTaskPromise(MethodInfo method, object inst, params object[] methodArgs)
        {
            if (method.ReturnType != typeof(Task))
                return null;

            object obj = method.Invoke(inst, methodArgs);
            return new DefaultTaskPromise((Task)obj);
        }
        //包装method的返回值
        private TaskPromise GetCustmoTaskPromise(MethodInfo method, object inst, params object[] methodArgs)
        {  
            return new DefaultResultTaskPromise<object>(Task.Factory.StartNew(()=> {
                return method.Invoke(inst, methodArgs);
            }));
        }


        /// <summary>
        /// 返回当前执行的任务
        /// </summary>
        /// <returns></returns>
        internal TaskPromise Execute()
        {
            //不存在放回类型的action
            if (this.Action.ReturnType == null)
            {
                return new DefaultTaskPromise(Task.Factory.StartNew(() => {
                    this.Action.Invoke(this.Controler.GetControlInst(), this.Parms?.Select(k => k.Value).ToArray());
                }));
            }

            //存在返回类型为Task<T>的action
            if (this.Action.ReturnType.IsGenericType && this.Action.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
            {
                return this.GetGenericDefaultTaskPromise(this.Action, this.Controler.GetControlInst(), this.Parms?.Select(k => k.Value).ToArray());
            }

            //存在返回类型为Task的action
            if (this.Action.ReturnType == typeof(Task))
            {
                return this.GetDefaultTaskPromise(this.Action, this.Controler.GetControlInst(), this.Parms?.Select(k => k.Value).ToArray());
            }

            //存在一个正常的返回值的action
            return this.GetCustmoTaskPromise(this.Action, this.Controler.GetControlInst(), this.Parms?.Select(k => k.Value).ToArray());
        }

    }
}
