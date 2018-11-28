using System.Threading.Tasks;

namespace CustomerServiceMobile.Contracts.Other
{
    public interface IToastService
    {
        void LongToast(string text);
        void ShortToast(string text);
        Task<bool> AskForConfirmation(string message);
    }
}
