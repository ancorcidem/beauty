using System;

namespace Beauty.Business.ServiceBus
{
    public interface IBus
    {
        void Subscribe<TMessage>(Action<TMessage> handler);
        void Publish<TMessage>(TMessage message);
        void Unsusbcribe<TMessage>(Action<TMessage> handler);
    }
}