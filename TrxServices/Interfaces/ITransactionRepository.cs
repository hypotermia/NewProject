using System.Threading.Tasks;
using TrxServices.Models;
namespace TrxServices.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<DetailTransaction>> GetTransactionAsync(); // Change the return type
        Task<DetailTransaction> GetTransactionByIdAsync(Guid uId);
        Task AddTransactionAsync(Transaction trx);
        Task UpdateTransactionAsync(Guid uId, Transaction trx);
        Task DeleteTransactionAsync(Guid uId);

    }
}
