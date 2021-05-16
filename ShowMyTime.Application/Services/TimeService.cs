using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShowMyTime.Application.Interfaces;
using ShowMyTime.Domain.Models;

namespace ShowMyTime.Application.Services
{
    public class TimeService : ITimeService
    {
        private readonly IWorldTimeApiService _apiService;
        private readonly IJsonService _jsonService;    
        private ConfigurationModel _config;
        private readonly List<TimeModel> _timeModels;

        public TimeService(IWorldTimeApiService apiService, IJsonService jsonService)
        {
            _apiService = apiService;
            _jsonService = jsonService;
            _timeModels = new List<TimeModel>();
            BuildConfigurationModel();
        }

        private void BuildConfigurationModel()
        {
            _config = _jsonService.DeserializeJsonToConfigurationModel();
        }

        public async Task<List<TimeModel>> GetLocalTimeByGivenLocation()
        {
            var returnedJson = await _apiService.GetJsonFromAPI(_config.BaseApiPath + _config.UserTimeZone);

            if (returnedJson == "404" || returnedJson == "503")
            {
                return await HandleExceptions(returnedJson);
            }
            else
            {
                var time = _jsonService.DeserializeJsonToTimeModel(returnedJson);

                _timeModels.Add(time);

                return _timeModels;
            }
        }

        private async Task<List<TimeModel>> HandleExceptions(string exception)
        {
            if (exception == "404")
            {
                var returnedJson = await _apiService.GetJsonFromAPI(_config.AllTimeZonesApiPath);

                if (returnedJson != "503")
                {
                    System.Console.WriteLine("Got 404");
                    TimeModel time404 = new TimeModel();

                    time404.AllTimeZones = returnedJson;
                    _timeModels.Add(time404);
                    return _timeModels;
                }
            }
                
            var time = new TimeModel(){
                ErrorMessage = "API service is currently unavailable."
            };

            _timeModels.Add(time);

            return _timeModels;
        }
    }
}