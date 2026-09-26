using BookingService.ApplicationLib.UnitOfWork;
using BookingService.InfrastructureLib.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace BookingService.InfrastructureLib.UnitOfWork
{
    public class UnitOfWork(BookingDbContext db) : IUnitOfWork
    {
        private IDbContextTransaction _transaction = null!;

        void IUnitOfWork.BeginTransaction(IsolationLevel isolationLevel)
        {
            if (db.Database.CurrentTransaction != null)
                throw new InvalidOperationException("Transaction could not start");

            _transaction = db.Database.BeginTransaction(isolationLevel);

        }

        void IUnitOfWork.Commit()
        {
            _transaction.Commit();
            _transaction.Dispose();
        }

        void IUnitOfWork.Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}
