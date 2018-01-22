using System.Reflection;
using NUnitLite;

namespace Axxes.SpaceXLaunchDates.Tests
{
    internal class Program
    {
        public static int Main(string[] args)
        {
            return new AutoRun(typeof(Program).GetTypeInfo().Assembly).Execute(args);
        }
    }
}