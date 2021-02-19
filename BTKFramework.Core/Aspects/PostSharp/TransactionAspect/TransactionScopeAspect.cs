using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BTKFramework.Core.Aspects.PostSharp.TransactionAspect
{
    [Serializable]
   public class TransactionScopeAspect:OnMethodBoundaryAspect
   {
        private TransactionScopeOption _option;

        public TransactionScopeAspect(TransactionScopeOption option)
        {
            _option = option;
        }

        public TransactionScopeAspect()
        {
         }
        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new TransactionScopeAspect(_option);
        }
        public override void OnSuccess(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Complete();
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();

        }
    }
}
