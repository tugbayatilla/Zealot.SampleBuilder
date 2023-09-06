﻿using Microsoft.Extensions.Logging;

namespace Zealot;

/// <summary>
/// Test Data Builder
/// </summary>
/// <typeparam name="TEntity">Given object</typeparam>
public interface ITestDataBuilder<out TEntity>
{
    /// <summary>
    /// Required: returns the expected object
    /// </summary>
    TEntity Build();
    
    /// <summary>
    /// Optional: overrides default value which is nothing
    /// set only the given type of the property, ignore the rest
    /// </summary>
    ITestDataBuilder<TEntity> WithOnly<TProperty>();
    
    /// <summary>
    /// Optional: overrides default value which is nothing
    /// set only the given type of the property, ignore the rest
    /// </summary>
    ITestDataBuilder<TEntity> WithOnly(Type type); 
    
    /// <summary>
    /// Optional: overrides the property with the given action
    /// </summary>
    ITestDataBuilder<TEntity> WithOverride(Action<TEntity> action);

    /// <summary>
    /// Optional: overrides default value which is UtcNow
    /// </summary>
    ITestDataBuilder<TEntity> WithDate(DateTime dateTime);

    /// <summary>
    /// Optional: overrides default value which is NewGuid
    /// </summary>
    ITestDataBuilder<TEntity> WithGuid(Guid guid);
    
    /// <summary>
    /// Optional: overrides default value which is 0.
    /// Determines how deep the recursion goes.
    /// </summary>
    ITestDataBuilder<TEntity> WithRecursionLevel(int recursionLevel);
    
    /// <summary>
    /// Optional: overrides default value which is nothing
    /// Adds the given string to the beginning of all string properties
    /// </summary>
    ITestDataBuilder<TEntity> WithStringPrefix(string prefix);
    
    /// <summary>
    /// Optional: overrides default value which is nothing
    /// Adds the given string to the end of all string properties
    /// </summary>
    ITestDataBuilder<TEntity> WithStringSuffix(string suffix);
    
    /// <summary>
    /// Optional: overrides default value which is 1.
    /// Uniqueness can be achieved with the incremental number.
    /// </summary>
    ITestDataBuilder<TEntity> WithStartingNumber(int startingNumber);
    
    /// <summary>
    /// Optional: overrides default value which is NullLogger.Instance.
    /// </summary>
    ITestDataBuilder<TEntity> WithLogger(ILogger logger);

    /// <summary>
    /// Optional: overrides default value which is 2.
    /// Lists will have elements which are given as size.
    /// </summary>
    ITestDataBuilder<TEntity> WithListSize(int size);

    /// <summary>
    /// Optional: overrides default value which is the property name.
    /// </summary>
    ITestDataBuilder<TEntity> WithStringBody(string body);

    /// <summary>
    /// Optional: overrides default value which is empty.
    /// </summary>
    ITestDataBuilder<TEntity> WithStringSeparator(string separator);

    /// <summary>
    /// Optional: add incremental value to the end of the string to creat uniqueness.
    /// Default is no unique number at the end of the string.
    /// </summary>
    ITestDataBuilder<TEntity> WithStringUniqueStartNumber(int uniqueStartingNumber);
}
