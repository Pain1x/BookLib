namespace BookLib.DAL.Interfaces
{
    /// <summary>
 /// Interface for realization of Unit of work pattern
 /// </summary>
    public interface IUnitOfWork
    {
        IDataRepository ADO { get; }
    }
}
