using System;
using System.Collections.Generic;
using Beauty.Business.Dal;

namespace Beauty.Business.ServiceBus
{
    public class Bus : IBus
    {
        private readonly IExecutionEngine _executionEngine;

        public Bus(IExecutionEngine executionEngine)
        {
            _executionEngine = executionEngine;
        }

        private readonly Dictionary<Type, List<object>> _messageHandlers = new Dictionary<Type, List<object>>();

        public void Subscribe<TMessage>(Action<TMessage> handler)
        {
            lock (_messageHandlers)
            {
                if (!_messageHandlers.ContainsKey(typeof (TMessage)))
                {
                    _messageHandlers[typeof (TMessage)] = new List<object>();
                }
                _messageHandlers[typeof (TMessage)].Add(handler);
            }
        }

        public void Publish<TMessage>(TMessage message)
        {
            lock (_messageHandlers)
            {
                if (!_messageHandlers.ContainsKey(message.GetType()))
                    return;

                _messageHandlers[message.GetType()].ForEach(x =>
                    {
                        var handler = (Action<TMessage>) x;
                        _executionEngine.Execute(() => handler(message));
                    });
            }
        }

        public void Unsusbcribe<TMessage>(Action<TMessage> handler)
        {
            lock (_messageHandlers)
            {
                if (!_messageHandlers.ContainsKey(typeof (TMessage)))
                {
                    return;
                }

                _messageHandlers[typeof (TMessage)].Remove(handler);
            }
        }
    }
}