using System.Diagnostics.CodeAnalysis;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.NUnit3;
using JetBrains.Annotations;

namespace Core2.Selkie.NUnit.Extensions
{
    [ExcludeFromCodeCoverage]
    [UsedImplicitly]
    public class AutoNSubstituteDataAttribute : AutoDataAttribute
    {
        public AutoNSubstituteDataAttribute()
            : base(() => new Fixture().Customize(new AutoConfiguredNSubstituteCustomization()))
        {
        }
    }
}