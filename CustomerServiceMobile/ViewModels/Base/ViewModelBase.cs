using CustomerServiceMobile.Contracts.Other;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CustomerServiceMobile.ViewModels.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected IMessagingService _messagingService;
        protected INavigationService _navigationService;
        protected IToastService _toastService;

        public ViewModelBase(IMessagingService messagingService,INavigationService navigationService
            , IToastService toastService
            )
        {
            _messagingService = messagingService;
            _navigationService = navigationService;
            _toastService = toastService;
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
