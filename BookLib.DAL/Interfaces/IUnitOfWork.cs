using BookLib.DAL.Repositories;

namespace BookLib.DAL.Interfaces
{
   public interface IUnitOfWork
    {
        IDataRepository ADO { get; }
    }
}
