﻿using System.Linq.Expressions;
using System.Reflection;

namespace Zealot.Strategies;

internal class ClassStrategy : Strategy
{
    public override async Task ExecuteAsync(IContext context, PropertyInfo propertyInfo)
    {
        if (!context.WithRecursionLevelContainer.CanContinueDeeper(propertyInfo.PropertyType))
            return;
        
        var instance = Instance.Create(propertyInfo.PropertyType);
        var newInstance = instance.WithContext(context).Build();
        
        propertyInfo.SetValue(context.Entity, newInstance);

        await Task.CompletedTask;
    }

    public override Expression<Func<PropertyInfo, bool>> ResolveCondition => info => info.PropertyType.IsClass;
}
