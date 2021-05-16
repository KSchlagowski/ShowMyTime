using System.Collections.Generic;
using System.Threading.Tasks;
using ShowMyTime.Domain.Models;

namespace ShowMyTime.Application.Interfaces
{
    public interface ITimeService
    {
        Task<List<TimeModel>> GetLocalTimeByGivenLocation();
    }
}