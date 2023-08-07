﻿namespace Zealot.Interfaces;

public interface IContext
{
    IContext CloneWithType(Type entityType);
    
    public IContext? Parent { get; }
    
    object Entity { get; }
    void SetEntity(object entity);
    
    Type EntityType { get; }
    string PropertyName { get; set; }
    
    IStrategyContainer StrategyContainer { get; }
    IWith With { get; }
}
