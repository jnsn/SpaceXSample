using System;
using System.Text;
using Newtonsoft.Json;

namespace Axxes.SpaceXLaunchDates.Models
{
    public class Launch
    {
        public string Details { get; set; }

        [JsonProperty("flight_number")]
        public int FlightNumber { get; set; }

        [JsonProperty("launch_date_utc")]
        public DateTime LaunchDate { get; set; }

        [JsonProperty("launch_success")]
        public bool Success { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Flight number : {FlightNumber}");
            stringBuilder.AppendLine($"Launch date   : {LaunchDate:dd/MM/yyyy HH:mm:ss}");
            stringBuilder.AppendLine($"Success       : {Success}");
            stringBuilder.AppendLine($"Details       : {Details}");

            return stringBuilder.ToString();
        }
    }
}