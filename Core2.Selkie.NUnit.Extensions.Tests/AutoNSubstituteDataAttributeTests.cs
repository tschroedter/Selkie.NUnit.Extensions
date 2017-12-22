using System;
using System.Diagnostics.CodeAnalysis;
using AutoFixture.NUnit3;
using JetBrains.Annotations;
using NSubstitute;
using NUnit.Framework;

namespace Core2.Selkie.NUnit.Extensions.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class AutoNSubstituteDataAttributeTests
    {
        [Test]
        [AutoNSubstituteData]
        public void AutoNSubstituteDataAttribute_ResolvesFrozen_WhenCalled(
            [NotNull] [Frozen] IOtherClass otherClass,
            [NotNull] MyClass sut)
        {
            // Arrange
            // Act
            sut.Run();

            // Assert
            otherClass.Received().Run();
        }
    }

    public class MyClass
    {
        public MyClass([NotNull] IOtherClass otherClass)
        {
            _otherClass = otherClass;
        }

        private readonly IOtherClass _otherClass;

        public void Run()
        {
            _otherClass.Run();
        }
    }

    public class OtherClass : IOtherClass
    {
        public void Run()
        {
            throw new NotImplementedException();
        }
    }

    public interface IOtherClass
    {
        void Run();
    }
}