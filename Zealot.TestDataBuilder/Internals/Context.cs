using Zealot.Interfaces;

namespace Zealot.Internals;

//todo: make this class move friendly. we need more higher level to hold configuration so
// when we clone the context, configuration will not be transferred and copied to next context.
internal class Context : IContext
{ 
    public Context(Type entityType, 
        IWith with, 
        IStrategyContainer strategyContainer)
    {
        With = with;
        StrategyContainer = strategyContainer;

        Scope = new Scope(null, entityType, null, null);
    }

    public IStrategyContainer StrategyContainer { get; }
    public IWith With { get; }
    
    public Scope Scope { get; set; }

    public IContext CloneWithType(Type entityType)
    {
        var newContext = new Context(entityType, 
            With, 
            StrategyContainer);

        newContext.Scope = newContext.Scope with {Parent = Scope};
        
        return newContext;
    }
}
