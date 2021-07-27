using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SummerPracticeWebServices2021.ApiModel
{
    public class CountryModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("visited")]
        public string Visited { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        public CountryModel(string name, string visited, string description, string url)
        {
            Name = name;
            Visited = visited;
            Description = description;
            Url = url;
        }
    }
}
