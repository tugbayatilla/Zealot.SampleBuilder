namespace Zealot.SampleBuilder.Tests.TestObjects;

public class InheritedClass : BaseClass
{
    public string BaseStringProp { get; set; }
}

public class BaseClass
{
    public string StringProp1 { get; set; }
    public List<string> ListOfStringProp { get; set; }
    
}

public class ClassHavingAnotherClassAsProperty
{
    public InheritedClass InheritedClassProp { get; set; }

    public string Prop { get; set; }
}

public class ClassHavingIListInterfaceAsProperty
{
    // ReSharper disable once InconsistentNaming
    public IList<ClassHavingAnotherClassAsProperty> IListInterfaceProperty { get; set; }
}

internal class ClassWithTwoDateTimeAndInheritFromClassWithTwoInteger : ClassWithTwoInteger
{
    public DateTime DateTimeProperty { get; set; }
}

internal class SampleDataPrimitiveConstructorSubClass
{
    public SampleDataPrimitiveConstructorSubClass(DateTime dateTime)
    {
        DateTimeProperty = dateTime;
    }

    public DateTime DateTimeProperty { get; set; }
}

internal class SampleDataWithDictionary
{
    public Dictionary<object, object> DictionaryProperty { get; set; }
    public Dictionary<string, int> DictionaryStringIntProperty { get; set; }
}


internal class ClassWithoutParameterlessConstructor
{
    public ClassWithoutParameterlessConstructor(ClassWithTwoString argument)
    {
        Prop1 = argument.Prop1;
        Prop2 = argument.Prop2;
    }
    public string Prop1 { get; set; }
    public string Prop2 { get; set; }
}
