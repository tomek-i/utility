


namespace TI.Utilities.Patterns.Visitor
{
    interface IFindingIVisitor<T> : IVisitor<T>
    {
        bool Found { get; }
        T SearchValue { get; }
    }
}