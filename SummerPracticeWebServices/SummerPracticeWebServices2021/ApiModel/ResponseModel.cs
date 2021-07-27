using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SummerPracticeWebServices2021.ApiModel
{
    public class ResponseModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }
    }
}
