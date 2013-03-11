using System;

namespace Beauty.Business.Dal
{
    public interface IExecutionEngine
    {
        void Execute(Action action);
    }
}