using System;
using System.Threading.Tasks;

namespace Beauty.Business.Dal
{
    public class AsyncExecutionEngine : IExecutionEngine
    {
        public void Execute(Action action)
        {
            Task.Factory.StartNew(action);
        }
    }
}