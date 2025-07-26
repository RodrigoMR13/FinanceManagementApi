using Application.Queries.TransactionType;
using Domain.Common.Models;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.TransactionType
{
    public class GetTransactionTypeByIdHandler : IRequestHandler<GetTransactionTypeByIdQuery, Result<Domain.Entities.TransactionType?>>
    {
        private readonly ITransactionTypeRepository _repository;

        public GetTransactionTypeByIdHandler(ITransactionTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Domain.Entities.TransactionType?>> Handle(GetTransactionTypeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
