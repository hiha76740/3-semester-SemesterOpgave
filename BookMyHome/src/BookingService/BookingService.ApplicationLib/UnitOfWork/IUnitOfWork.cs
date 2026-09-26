using System.Data;

namespace BookingService.ApplicationLib.UnitOfWork;

public interface IUnitOfWork
{
    void Commit();

    void Rollback();

    void BeginTransaction(IsolationLevel isolationLevel);
}
