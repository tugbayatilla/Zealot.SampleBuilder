using Zealot.Interfaces;
using Zealot.SampleBuilder.Tests.TestObjects;
using Zealot.Strategies;

namespace Zealot.SampleBuilder.Tests;

public class WithStrategyTests
{
    [Fact]
    public void WithStrategy_Unsupported()
    {
        Assert.Throws<NotSupportedException>(() =>
        {
             TestDataBuilder
                .For<ClassWithTwoIntPtr>()
                .Build();
        });
        
        var entity = TestDataBuilder
            .For<ClassWithTwoIntPtr>()
            .WithStrategy(new NIntStrategy())
            .Build();

        entity.Prop1.Should().Be(1);

    }
    
    
}

internal class NIntStrategy : Strategy
{
    public override IEnumerable<Type> AvailableTypes => new[] { typeof(IntPtr) };
    public override object GenerateValue(IContext context, Type type)
    {
        return IntPtr.Parse("1");
    }
}