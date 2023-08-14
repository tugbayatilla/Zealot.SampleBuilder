using Zealot.Interfaces;
using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class BuildTests
{
    [Fact]
    public void For_returns_builder_interface()
    {
        TestDataBuilder
            .For<ClassWithNoProperty>()
            .Should()
            .BeAssignableTo<IBuilder<ClassWithNoProperty>>();
    }

    [Fact]
    public void Build_always_creates_an_instance()
    {
        TestDataBuilder
            .For<ClassWithNoProperty>()
            .Build()
            .Should()
            .NotBeNull();
    }

    [Fact]
    public void Throws_Exception_for_unsupported_types()
    {
        Action exception = () => TestDataBuilder.For<ClassWithIntPtr>().Build();
        exception
            .Should()
            .Throw<NotSupportedException>()
            .WithMessage($"The strategy with type '{typeof(IntPtr).FullName}' is not supported.");
    }
}
