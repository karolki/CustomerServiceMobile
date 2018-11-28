using CustomerService.DTO.Creation;
using CustomerService.DTO.Output;
using CustomerService.DTO.Update;
using CustomerServiceMobile.Utility;
using CustomerServiceMobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CustomerServiceMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            AppContainer.RegisterDependencies();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CustomerDTO, CustomerUpdateDTO>()
                    .ForMember(dto => dto.FirstName, opt => opt.MapFrom(udto =>
                     udto.Name.Substring(0, udto.Name.LastIndexOf(" "))))
                     .ForMember(dto => dto.LastName, opt => opt.MapFrom(udto =>
                     udto.Name.Substring(udto.Name.LastIndexOf(" ")+1)));

                cfg.CreateMap<CustomerUpdateDTO, CustomerCreationDTO>();


                cfg.CreateMap<ShippingAddressCreationDTO, ShippingAddressUpdateDTO>();

                cfg.CreateMap<ShippingAddressUpdateDTO, ShippingAddressCreationDTO>();
            });
            MainPage = new RootPage();
        }
    }
}
