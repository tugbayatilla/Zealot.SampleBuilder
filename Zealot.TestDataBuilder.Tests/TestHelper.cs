using Zealot.Internals;

namespace Zealot.SampleBuilder.Tests;

public static class TestHelper
{
    /// <summary>
    /// Check every property in object if they are default except given property types
    /// </summary>
    /// <param name="obj"></param>
    /// <typeparam name="TProperty"></typeparam>
    public static void CheckDefaultExcept<TProperty>(object obj)
    {
        var props = obj.GetType().GetProperties();
        foreach (var prop in props)
        {
            if(prop.PropertyType.IsSame(typeof(TProperty))) continue;
            
            prop.GetValue(obj).Should().Be(prop.IsNullable() ? default : prop.PropertyType.GetDefault());
        }
    }

    public static void AssertAllPropertiesWithSetOnly(object obj, Type setOnlyType)
    {
        var props = obj.GetType().GetProperties();
        foreach (var prop in props)
        {
            //skip bool because it can be compared
            if (prop.PropertyType == typeof(bool)) return;
            
            if(prop.PropertyType.IsSame(setOnlyType))
                prop.GetValue(obj).Should().NotBe(prop.IsNullable() ? default : prop.PropertyType.GetDefault(), 
                    $"{prop.Name} should not be {prop.PropertyType.GetDefault() ?? "null"}");
            else
            {
                prop.GetValue(obj).Should().Be(prop.IsNullable() ? default : prop.PropertyType.GetDefault(), 
                    $"{prop.Name} should be {prop.PropertyType.GetDefault() ?? "null"}");
            }
        }
    }
}