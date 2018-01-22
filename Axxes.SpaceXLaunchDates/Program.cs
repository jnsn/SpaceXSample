using System;
using Axxes.SpaceXLaunchDates.Services;
using NodaTime;

namespace Axxes.SpaceXLaunchDates
{
    internal class Program
    {
        private static void Main()
        {
            var clock = SystemClock.Instance;
            var spaceXApiService = new SpaceXApiService();
            var launchService = new LaunchService(spaceXApiService, clock);

            launchService.LoadAllLaunches();

            var thisYearsLaunches = launchService.GetThisYearsLaunches();

            foreach (var launch in thisYearsLaunches)
            {
                Console.WriteLine(launch.ToString());
                Console.WriteLine(Environment.NewLine);
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("COMPLETED...");
            Console.WriteLine(Environment.NewLine);

            Console.ReadKey();
        }
    }
}