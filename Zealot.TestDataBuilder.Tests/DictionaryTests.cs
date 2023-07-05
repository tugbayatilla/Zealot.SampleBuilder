using Zealot.SampleBuilder.Tests.TestObjects;

namespace Zealot.SampleBuilder.Tests;

public class DictionaryTests
{
    [Fact]
    public void Support_dictionary()
    {
        var entity = TestDataBuilder
            .For<InternalWithDictionary>()
            .Build();

        entity.DictionaryProp.Should().NotBeNull();
        entity.DictionaryStringIntProp.Should().NotBeNull();
    }
    [Fact]
    public void Support_IReadOnlyDictionary()
    {
        var entity = TestDataBuilder
            .For<InternalWithDictionary>()
            .WithOnly(typeof(IReadOnlyDictionary<,>))
            .Build();

        entity.IReadOnlyDictionaryStringIntProp.Should().NotBeNull();
    }
    
    [Fact]
    public void Support_dictionary_string_int_has_2_items()
    {
        var entity = TestDataBuilder
            .For<DictionaryStringIntClass>()
            .Build();

        entity.DictionaryStringIntProp.Count.Should().Be(2);
    }
    
    [Fact]
    public void Support_dictionary_int_complex_has_2_items()
    {
        var entity = TestDataBuilder
            .For<DictionaryIntPublicWithAllClass>()
            .Build();

        entity.DictionaryIntPublicWithAllProp.Count.Should().Be(2);
        entity.DictionaryIntPublicWithAllProp.Values.First().Should().NotBeNull();
    }
    
    [Fact]
    public void Support_dictionary_string_complex_has_2_items()
    {
        var entity = TestDataBuilder
            .For<DictionaryStringPublicWithAllClass>()
            .Build();

        entity.DictionaryStringPublicWithAllProp.Count.Should().Be(2);
        entity.DictionaryStringPublicWithAllProp.Values.First().Should().NotBeNull();
    }
    
    [Fact]
    public void Support_IReadOnlyDictionary_has_2_values()
    {
        var entity = TestDataBuilder
            .For<InternalWithDictionary>()
            .WithOnly(typeof(IReadOnlyDictionary<,>))
            .Build();

        entity.IReadOnlyDictionaryStringIntProp.Count.Should().Be(2);
    }
    
}
