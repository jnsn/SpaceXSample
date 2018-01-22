using System.Collections.Generic;
using System.Linq;
using System.Net;
using Axxes.SpaceXLaunchDates.Models;
using NodaTime;

namespace Axxes.SpaceXLaunchDates.Services
{
    public class LaunchService : ILaunchService
    {
        private readonly IClock _clock;
        private readonly ISpaceXApiService _spaceXApiService;
        private List<Launch> _launches = new List<Launch>();

        public LaunchService(ISpaceXApiService spaceXApiService, IClock clock)
        {
            _spaceXApiService = spaceXApiService;
            _clock = clock;
        }

        public void LoadAllLaunches()
        {
            var response = _spaceXApiService.GetAllLaunches();
            _launches = response.StatusCode == HttpStatusCode.OK ? response.Data : new List<Launch>();
        }

        public List<Launch> GetThisYearsLaunches()
        {
            var thisYear = _clock.GetCurrentInstant().ToDateTimeUtc().Year;
            var thisYearsLaunches = _launches.Where(l => l.LaunchDate.Year == thisYear).ToList();

            return thisYearsLaunches;
        }

        public List<Launch> GetLastYearsLaunches()
        {
            var lastYear = _clock.GetCurrentInstant().ToDateTimeUtc().Year - 1;
            var lastYearsLaunches = _launches.Where(l => l.LaunchDate.Year == lastYear).ToList();

            return lastYearsLaunches;
        }
    }

    public interface ILaunchService
    {
        void LoadAllLaunches();
        List<Launch> GetThisYearsLaunches();
        List<Launch> GetLastYearsLaunches();
    }
}