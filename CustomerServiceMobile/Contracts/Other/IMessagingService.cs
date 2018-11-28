using System;

namespace CustomerServiceMobile.Contracts.Other
{
    public interface IMessagingService
    {
        void Send<T, TR>(T sender, string message, TR data) where T : class;

        void Subscribe<T, Targ>(object subscriber, string message, Action<T, Targ> action) where T : class;
    }
}
