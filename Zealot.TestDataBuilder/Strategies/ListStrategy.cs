﻿using System.Reflection;

namespace Zealot.Strategies;

public class ListStrategy : IStrategy
{
    public async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        var listType = typeof(List<>).MakeGenericType(propertyInfo.PropertyType.GenericTypeArguments);
        var listInstance = Instance.Create(listType);
        
        propertyInfo.SetValue(context.Entity, listInstance);
        
        await Task.CompletedTask;
    }

    public IEnumerable<Type> AvailableTypes =>
        new[] {
            typeof(IList<>),
            typeof(ICollection<>)
        };
}