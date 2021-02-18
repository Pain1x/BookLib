using BookLib.DAL.Interfaces;

namespace BookLib.DAL.Repositories
{
    /// <summary>
    /// Class that implemets IUnitOfWork interface
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private AdoRepository adoRepository;
        public IDataRepository ADO
        {
            get
            {
                if (adoRepository == null)
                    adoRepository = new AdoRepository();
                return adoRepository;
            }
        }

    }
}
