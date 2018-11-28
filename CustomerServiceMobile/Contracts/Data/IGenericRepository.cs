using System.Threading.Tasks;

namespace CustomerServiceMobile.Contracts.Data
{
    public interface IGenericRepository
    {
        Task<T> GetAsync<T>(string uri);

        Task PostAsync(string uri, object data);

        //Task<T> PostAsync<T>(string uri, object data);

        //Task<TR> PostAsync<T, TR>(string uri, T data);

        Task PutAsync(string uri, object data);

        Task DeleteAsync(string uri);
    }
}
