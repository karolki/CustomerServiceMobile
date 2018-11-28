using CustomerServiceMobile.Enums;
using Xamarin.Forms;

namespace CustomerServiceMobile.Models
{
    public class CustomerMenuItem : BindableObject
    {
        public MenuItemType Id { get; set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
    }
}
