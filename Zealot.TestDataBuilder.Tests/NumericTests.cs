using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class NumericTests
{
    [Fact]
    public void Support_one_integer()
    {
        TestDataBuilder.For<PublicWithOneInt>().Build().IntProp.Should().Be(1);
    }
    
    [Fact]
    public void Support_one_float()
    {
        TestDataBuilder.For<PublicWithOneFloat>().Build().FloatProp.Should().Be(1);
    }
    
    [Fact]
    public void Support_two_integers()
    {
        var subject = TestDataBuilder.For<PublicWithTwoInt>().Build();
        subject.IntProp.Should().NotBe(0);
        subject.IntProp2.Should().NotBe(0);

        subject.IntProp.Should().NotBe(subject.IntProp2);
    }
    
    [Fact]
    public void Support_two_double()
    {
        var subject = TestDataBuilder.For<PublicWithTwoDouble>().Build();
        subject.DoubleProp.Should().NotBe(0);
        subject.DoubleProp.Should().NotBe(0);

        subject.DoubleProp.Should().NotBe(subject.DoubleProp2);
    }
}
