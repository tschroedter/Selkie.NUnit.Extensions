using System.Diagnostics.CodeAnalysis;

namespace Selkie.NUnit.Extensions
{
    [ExcludeFromCodeCoverage]
    //ncrunch: no coverage start
    public sealed class Constants
    {
        public const double EpsilonRadians = 1E-10;
        public const double EpsilonDegrees = 1E-10;
        public const double EpsilonPointXy = 1E-2;
        public const double EpsilonDistance = 1E-2;
        public const double Epsilon = 0.01;
    }

    //ncrunch: no coverage end
}