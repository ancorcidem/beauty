using System;
using Beauty.Business.Dal;

namespace Beauty.Business.Specs
{
    public class SyncExecutionEngine : IExecutionEngine
    {
        public void Execute(Action action)
        {
            action();
        }
    }
}