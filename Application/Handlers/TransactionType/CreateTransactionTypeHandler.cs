using Application.Commands.TransactionType;
using Domain.Common.Models;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.TransactionType
{
    public class CreateTransactionTypeHandler : IRequestHandler<CreateTransactionTypeCommand, Result<Domain.Entities.TransactionType>>
    {
        private readonly ITransactionTypeRepository _repository;

        public CreateTransactionTypeHandler(ITransactionTypeRepository transactionTypeRepository)
        {
            _repository = transactionTypeRepository;
        }

        public async Task<Result<Domain.Entities.TransactionType>> Handle(CreateTransactionTypeCommand request, CancellationToken cancellationToken)
        {
            return await _repository.CreateAsync(new Domain.Entities.TransactionType() { Name = request.Name });
        }
    }
}
