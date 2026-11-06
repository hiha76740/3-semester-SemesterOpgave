using System.Data;

namespace BookingService.ApplicationLib.UnitOfWork;
/// <summary>
/// 
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// 
    /// </summary>
    void Commit();
    /// <summary>
    /// 
    /// </summary>
    void Rollback();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="isolationLevel"></param>
    void BeginTransaction(IsolationLevel isolationLevel);
}
