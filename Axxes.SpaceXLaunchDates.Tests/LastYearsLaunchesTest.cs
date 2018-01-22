using NUnit.Framework;

namespace Axxes.SpaceXLaunchDates.Tests
{
    public class LastYearsLaunchesTest : LaunchServiceTestBase
    {
        [Test]
        public void GetLastYearsLaunches()
        {
            Execute();
        }

        public void WhenIRequestLastYearsLaunches()
        {
            Launches = Service.GetLastYearsLaunches();
        }

        public void ThenOnlyTwoLaunchesAreIncluded()
        {
            Assert.That(Launches.Count, Is.EqualTo(2));
        }
    }
}