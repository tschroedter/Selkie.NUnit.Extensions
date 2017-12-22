using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

// ReSharper disable UnusedMember.Global

namespace Core2.Selkie.NUnit.Extensions
{
    [ExcludeFromCodeCoverage]
    [UsedImplicitly]
    public sealed class Constants
    {
        public const double EpsilonRadians = 1E-10;
        public const double EpsilonDegrees = 1E-10;
        public const double EpsilonPointXy = 1E-2;
        public const double EpsilonDistance = 1E-2;
        public const double Epsilon = 0.01;
    }
}