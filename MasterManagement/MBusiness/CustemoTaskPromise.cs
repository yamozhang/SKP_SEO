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
