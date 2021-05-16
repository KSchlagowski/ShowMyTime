using System.Threading.Tasks;

namespace ShowMyTime.Application.Interfaces
{
    public interface IWorldTimeApiService
    {
        Task<string> GetJsonFromAPI (string exactApiPath);
    }
}