using NUnit.Framework;

namespace Axxes.SpaceXLaunchDates.Tests
{
    public class ThisYearsLaunchesTest : LaunchServiceTestBase
    {
        [Test]
        public void GetThisYearsLaunches()
        {
            Execute();
        }

        public void WhenIRequestThisYearsLaunches()
        {
            Launches = Service.GetThisYearsLaunches();
        }

        public void ThenOnlyThreeLaunchesAreIncluded()
        {
            Assert.That(Launches.Count, Is.EqualTo(3));
        }
    }
}