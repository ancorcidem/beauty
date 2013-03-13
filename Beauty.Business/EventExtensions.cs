using System;

namespace Beauty.Business
{
    public static class EventExtensions
    {
        public static void Raise<TEventArgs>(this EventHandler<TEventArgs> eventHandler, object sender,
                                             TEventArgs eventArgs)
            where TEventArgs : EventArgs
        {
            if (eventHandler != null)
            {
                eventHandler(sender, eventArgs);
            }
        }
    }
}