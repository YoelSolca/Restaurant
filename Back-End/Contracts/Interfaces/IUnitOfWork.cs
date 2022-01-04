namespace Contracts.Interfaces
{
    public interface IUnitOfWork
    {
        IFoodsRepository Foods { get; }
    }
}
