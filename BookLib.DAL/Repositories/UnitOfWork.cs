using BookLib.DAL.Entities;
using BookLib.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLib.DAL.Repositories
{
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
