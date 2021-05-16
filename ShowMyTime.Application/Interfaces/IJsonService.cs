using System.Collections.Generic;
using ShowMyTime.Domain.Models;

namespace ShowMyTime.Application.Interfaces
{
    public interface IJsonService
    {
        TimeModel DeserializeJsonToTimeModel(string json);
        ConfigurationModel DeserializeJsonToConfigurationModel();
    }
}