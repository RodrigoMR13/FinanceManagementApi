using Domain.Common.Models;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Postgres.Context;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Infrastructure.Repositories
{
    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        private readonly FinanceDbContext _context;

        public TransactionTypeRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<Result<IEnumerable<TransactionType>>> GetAllAsync()
        {
            try
            {
                var result = await _context.TransactionTypes.AsNoTracking().ToListAsync();

                return Result<IEnumerable<TransactionType>>.Ok(result);
            }
            catch (DbException ex)
            {
                // TO DO: Logar exception de BD
                return Result<IEnumerable<TransactionType>>.Fail($"Erro ao buscar no Banco de Dados.\n Exception: {ex.Message}");
            }
        }

        public async Task<Result<TransactionType?>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _context.TransactionTypes.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
                return Result<TransactionType?>.Ok(result);
            }
            catch (DbException ex)
            {
                // TO DO: Logar exception de BD
                return Result<TransactionType?>.Fail($"Erro ao buscar {id} no Banco de Dados.\n Exception: {ex.Message}");
            }
        }

        public async Task<Result<TransactionType>> CreateAsync(TransactionType transactionType)
        {
            try
            {
                _context.TransactionTypes.Add(transactionType);
                await _context.SaveChangesAsync();

                return Result<TransactionType>.Ok(transactionType);
            }
            catch (DbException ex)
            {
                // TO DO: Logar exception de BD
                return Result<TransactionType>.Fail($"Erro ao criar {transactionType.Name} no Banco de Dados.\n Exception: {ex.Message}");
            }
        }

        public async Task<Result<bool>> UpdateAsync(TransactionType transactionType)
        {
            try
            {
                var existing = await _context.TransactionTypes.FindAsync(transactionType.Id);
                if (existing == null)
                    return Result<bool>.Fail("Registro não encontrado.");

                existing.Name = transactionType.Name;

                await _context.SaveChangesAsync();
                return Result<bool>.Ok(true);
            }
            catch (DbException ex)
            {
                // TO DO: Logar exception de BD
                return Result<bool>.Fail($"Erro ao atualizar {transactionType.Name} no Banco de Dados.\n Exception: {ex.Message}");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var deletedCount = await _context.TransactionTypes
                    .Where(x => x.Id == id)
                    .ExecuteDeleteAsync();

                if (deletedCount == 0)
                    return Result<bool>.Fail($"TransactionType com Id={id} não encontrado.");

                return Result<bool>.Ok(true);
            }
            catch (DbException ex)
            {
                // TO DO: Logar exception de BD
                return Result<bool>.Fail($"Erro ao deletar TransactionType com Id={id} no Banco de Dados.\n Exception: {ex.Message}");
            }
        }
    }
}
