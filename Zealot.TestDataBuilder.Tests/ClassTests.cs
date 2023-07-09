using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class ClassTests
{
    [Fact]
    public void Support_class()
    {
        var entity = TestDataBuilder
            .For<ClassWithOneClassWithAllPrimitives>()
            .Build();

        entity.Prop.Should().NotBeNull();
    }
    
    
}
