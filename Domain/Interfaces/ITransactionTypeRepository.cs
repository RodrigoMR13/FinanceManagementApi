using Domain.Common.Models;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITransactionTypeRepository
    {
        Task<Result<IEnumerable<TransactionType>>> GetAllAsync();
        Task<Result<TransactionType?>> GetByIdAsync(int id);
        Task<Result<TransactionType>> CreateAsync(TransactionType transactionType);
        Task<Result<bool>> UpdateAsync(TransactionType transactionType);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
