using System;
using System.Collections.Generic;
using System.IO;
using ShowMyTime.Application.Interfaces;
using ShowMyTime.Domain.Models;
using Newtonsoft.Json;

namespace ShowMyTime.Application.Services
{
    public class JsonService : IJsonService
    {
        public TimeModel DeserializeJsonToTimeModel(string json)
        {
            WorldtimeApiJsonModel apiJsonModel  = JsonConvert.DeserializeObject<WorldtimeApiJsonModel>(json);
            TimeModel time = new TimeModel()
            {
                TimeZone = apiJsonModel.timezone,
                CurrentTime = PullOutTimeFromDateTime(apiJsonModel.datetime)
            };

            return time;
        }

        private string PullOutTimeFromDateTime(string datetime)
        {
            string time = datetime.Substring(11,8);

            return time;
        }

        public ConfigurationModel DeserializeJsonToConfigurationModel()
        {
            try
            {
                var config = JsonConvert.DeserializeObject<ConfigurationModel>(
                    File.ReadAllText(@"../ShowMyTimeConfigurationFile.json")
                );

                return config;
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e);
                return null;
            }
        }
    }
}