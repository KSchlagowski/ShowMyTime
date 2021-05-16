using System.Threading.Tasks;

namespace ShowMyTime.Application.Interfaces
{
    public interface IWorldTimeApiRepository
    {
        Task<string> GetJsonFromAPI (string exactApiPath);
        //Task<string> GetAllTimeZones (string exactApiPath);
    }
}