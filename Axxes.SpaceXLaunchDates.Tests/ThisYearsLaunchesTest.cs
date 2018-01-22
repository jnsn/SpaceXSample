using NUnit.Framework;
using TestStack.BDDfy;

namespace Axxes.SpaceXLaunchDates.Tests
{
    public class ThisYearsLaunchesTest : LaunchServiceTestBase
    {
        [Test]
        public void GetThisYearsLaunches()
        {
            this.BDDfy();
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