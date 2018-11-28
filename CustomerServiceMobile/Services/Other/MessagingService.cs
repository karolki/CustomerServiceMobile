using CustomerServiceMobile.Contracts.Other;
using System;
using Xamarin.Forms;

namespace CustomerServiceMobile.Services.Other
{
    public class MessagingService : IMessagingService
    {
        public void Send<T, TR>(T sender, string message, TR data) where T : class
        {
            MessagingCenter.Send(sender, message, data);
        }

        public void Subscribe<T,Targ>(object subscriber, string message, Action<T,Targ> action) where T : class
        {
            MessagingCenter.Subscribe(subscriber, message,action);
        }
    }
}
