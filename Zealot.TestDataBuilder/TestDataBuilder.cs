using Zealot.Interfaces;
using Zealot.Internals;
using Zealot.Withs;

namespace Zealot;

public static class TestDataBuilder
{
    /// <summary>
    /// Required
    /// </summary>
    public static IBuilder<TEntity> For<TEntity>()
        where TEntity : new()
    {
        IContext context = new Context(
            typeof(TEntity), 
            new With(),
            new StrategyContainer());

        return new Builder<TEntity>(context);
    }
}
