﻿using System;
using Beauty.Business.Dal;

namespace Beauty.Specs.Common
{
    public class SyncExecutionEngine : IExecutionEngine
    {
        public void Execute(Action action)
        {
            action();
        }
    }
}