using System;
using System.Threading.Tasks;
using MEventBus;

namespace MBusiness
{
    /// <summary>
    /// 一个自定的TaskPromise，可任意设置其属性
    /// </summary>
    internal class CustemoTaskPromise : TaskPromise
    {
        public override bool IsComplete => this.Complete;
        public override bool IsFail => this.Fail;
        public override Exception Exception => this.Error;
        
        //反射     
        /*
         C# OOP    ===>  指令(顺序/pop)
         编译器   ==>  IL(中间语言，接近汇编)     table（元数据） => 方法名/属性名/字段/事件 等等等等（运行时）
         JIT     (运行时)==>   (即时)编译中间语言   ==> 二进制代码
         */
        internal bool Complete { get; set; }
        internal bool Fail { get; set; }
        internal Exception Error { get; set; }
        internal object Result { get; set; }
        internal Action<TaskPromise> CutemoCallBack { get; set; }


        /// <summary>
        /// 设置结果，此行为表示有结果了，执行成功了
        /// </summary>
        internal void SetResult(object result)
        {
            this.Result = result;//设置result
            this.Complete = true;//任务完成
            this.CallCustemoCallBack();//执行回调
        }
        internal void CallCustemoCallBack()
        {
            this.CutemoCallBack?.Invoke(this);
        }

        public override void SetCompleteInvoke(Action<TaskPromise> callBack)
        {
            this.CutemoCallBack = callBack;
        }
        public override object GetResult()
        {
            return this.Result;
        }
    }
}
