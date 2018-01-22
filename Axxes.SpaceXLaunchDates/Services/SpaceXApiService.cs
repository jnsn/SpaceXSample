using System.Collections.Generic;
using Axxes.SpaceXLaunchDates.Helpers;
using Axxes.SpaceXLaunchDates.Models;
using RestSharp;

namespace Axxes.SpaceXLaunchDates.Services
{
    public class SpaceXApiService : ISpaceXApiService
    {
        private const string ApiUrl = "https://api.spacexdata.com";

        public IRestResponse<List<Launch>> GetAllLaunches()
        {
            var client = new AxxesRestClient(ApiUrl);
            var request = new RestRequest("v2/launches", Method.GET);
            var response = client.Execute<List<Launch>>(request);

            return response;
        }
    }

    public interface ISpaceXApiService
    {
        IRestResponse<List<Launch>> GetAllLaunches();
    }
}