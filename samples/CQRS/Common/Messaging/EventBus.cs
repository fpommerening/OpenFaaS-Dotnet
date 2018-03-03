using System;
using Domain.Events;
using EasyNetQ;

namespace Messaging
{
    public class EventBus : IDisposable
    {
        private IBus _bus;

        private IBus Bus()
        {
            return _bus ?? (_bus = RabbitHutch.CreateBus("host=localhost"));
        }

        public void Publish<T>(T eventData) where T : EventBase
        {
            Bus().PublishAsync(eventData, typeof(T).Name);
        }

        public void Dispose()
        {
            _bus?.Dispose();
        }
    }
}
