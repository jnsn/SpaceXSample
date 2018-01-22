using System;
using System.Collections.Generic;
using System.Net;
using Axxes.SpaceXLaunchDates.Models;
using Axxes.SpaceXLaunchDates.Services;
using Moq;
using NodaTime;
using NodaTime.Testing;
using RestSharp;
using TestStack.BDDfy;

namespace Axxes.SpaceXLaunchDates.Tests
{
    public class LaunchServiceTestBase
    {
        private IClock _clock;
        private Mock<ISpaceXApiService> _spaceXApiService;

        protected List<Launch> Launches { get; set; }
        protected ILaunchService Service { get; set; }

        public void Setup()
        {
            var restResponse = new Mock<IRestResponse<List<Launch>>>();
            restResponse.Setup(x => x.Data).Returns(GetTestLaunches());
            restResponse.Setup(x => x.StatusCode).Returns(HttpStatusCode.OK);

            _spaceXApiService = new Mock<ISpaceXApiService>();
            _spaceXApiService.Setup(x => x.GetAllLaunches()).Returns(restResponse.Object);
        }

        public void Execute()
        {
            this.BDDfy();
        }

        public void AndGivenASetOfLaunches()
        {
            Service = new LaunchService(_spaceXApiService.Object, _clock);
            Service.LoadAllLaunches();
        }

        public void GivenTheCurrentYearIs2017()
        {
            _clock = FakeClock.FromUtc(2017, 1, 22, 20, 0, 0);
        }

        private static List<Launch> GetTestLaunches()
        {
            return new List<Launch>
            {
                new Launch
                {
                    FlightNumber = 1,
                    LaunchDate = new DateTime(2017, 1, 1),
                    Success = true
                },
                new Launch
                {
                    FlightNumber = 2,
                    LaunchDate = new DateTime(2017, 2, 1),
                    Success = true
                },
                new Launch
                {
                    FlightNumber = 3,
                    LaunchDate = new DateTime(2017, 3, 1),
                    Success = true
                },
                new Launch
                {
                    FlightNumber = 4,
                    LaunchDate = new DateTime(2016, 1, 1),
                    Success = true
                },
                new Launch
                {
                    FlightNumber = 5,
                    LaunchDate = new DateTime(2016, 2, 1),
                    Success = true
                }
            };
        }
    }
}