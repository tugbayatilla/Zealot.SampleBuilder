using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class NumericTests
{
    [Theory]
    [InlineData(typeof(string))]
    [InlineData(typeof(int))]
    [InlineData(typeof(int?))]
    [InlineData(typeof(double))]
    [InlineData(typeof(double?))]
    [InlineData(typeof(float))]
    [InlineData(typeof(float?))]
    [InlineData(typeof(long))]
    [InlineData(typeof(long?))]
    [InlineData(typeof(short))]
    [InlineData(typeof(short?))]
    public void Support_type(Type setOnlyType)
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .WithOnly(setOnlyType)
            .Build();

        TestHelper.AssertAllPropertiesWithSetOnly(subject, setOnlyType);
    }
    
    [Fact]
    public void Support_integer()
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .WithOnly<int>()
            .Build();

        subject.IntProp.Should().NotBe(0);
        subject.IntProp2.Should().NotBe(0);

        subject.IntProp.Should().NotBe(subject.IntProp2);

        TestHelper.CheckDefaultExcept<int>(subject);
    }

    [Fact]
    public void Support_double()
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .WithOnly<double>()
            .Build();
        subject.DoubleProp.Should().NotBe(0);
        subject.DoubleProp2.Should().NotBe(0);

        subject.DoubleProp.Should().NotBe(subject.DoubleProp2);
    }
    
    [Fact]
    public void Support_short()
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .WithOnly<short>()
            .Build();
        
        subject.ShortProp.Should().NotBe(0);
        subject.ShortProp2.Should().NotBe(0);

        subject.ShortProp.Should().NotBe(subject.ShortProp2);
    }
    
    [Fact]
    public void Support_integer_nullable()
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .WithOnly<int?>()
            .Build();
        
        subject.IntNullableProp.Should().NotBe(0);
        subject.IntNullableProp2.Should().NotBe(0);

        subject.IntNullableProp.Should().NotBe(subject.IntNullableProp2);
    }
    
    [Fact]
    public void Support_short_nullable()
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .WithOnly<short?>()
            .Build();
        
        subject.ShortNullableProp.Should().NotBeNull();
        subject.ShortNullableProp2.Should().NotBeNull();

        subject.ShortNullableProp.Should().NotBe(0);
        subject.ShortNullableProp2.Should().NotBe(0);

        subject.ShortNullableProp.Should().NotBe(subject.ShortNullableProp2);
    }
    
    [Fact]
    public void Support_double_nullable()
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .WithOnly<double?>()
            .Build();
        
        subject.DoubleNullableProp.Should().NotBeNull();
        subject.DoubleNullableProp2.Should().NotBeNull();
        
        subject.DoubleNullableProp.Should().NotBe(0);
        subject.DoubleNullableProp2.Should().NotBe(0);

        subject.DoubleNullableProp.Should().NotBe(subject.DoubleNullableProp2);
    }

    [Fact]
    public void Support_float_nullable()
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .WithOnly<float?>()
            .Build();
        
        subject.FloatNullableProp.Should().NotBeNull();
        subject.FloatNullableProp2.Should().NotBeNull();
        
        subject.FloatNullableProp.Should().NotBe(0);
        subject.FloatNullableProp2.Should().NotBe(0);

        subject.FloatNullableProp.Should().NotBe(subject.FloatNullableProp2);
    }
    
    [Fact]
    public void Support_float()
    {
        var subject = TestDataBuilder.For<PublicWithAll>()
                .WithOnly<float>()
                .Build();
        subject.FloatProp.Should().NotBe(0);
        subject.FloatProp2.Should().NotBe(0);

        subject.FloatProp.Should().NotBe(subject.FloatProp2);
    }
    
    [Fact]
    public void Support_unsigned_int16()
    {
        var subject = TestDataBuilder
            .For<PublicWithAll>()
            .WithOnly<UInt16>()
            .Build();
        subject.UInt16Prop.Should().NotBe(0);
        subject.UInt16Prop2.Should().NotBe(0);

        subject.UInt16Prop.Should().NotBe(subject.UInt16Prop2);
    }
}
