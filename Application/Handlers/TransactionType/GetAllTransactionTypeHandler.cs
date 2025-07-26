using Application.Queries.TransactionType;
using Domain.Common.Models;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.TransactionType
{
    public class GetAllTransactionTypeHandler : IRequestHandler<GetAllTransactionTypeQuery, Result<IEnumerable<Domain.Entities.TransactionType>>>
    {
        private readonly ITransactionTypeRepository _repository;

        public GetAllTransactionTypeHandler(ITransactionTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<Domain.Entities.TransactionType>>> Handle(GetAllTransactionTypeQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
