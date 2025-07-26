using Application.Commands.TransactionType;
using Domain.Common.Models;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.TransactionType
{
    public class DeleteTransactionTypeHandler : IRequestHandler<DeleteTransactionTypeCommand, Result<bool>>
    {
        private readonly ITransactionTypeRepository _repository;

        public DeleteTransactionTypeHandler(ITransactionTypeRepository transactionTypeRepository)
        {
            _repository = transactionTypeRepository;
        }

        public async Task<Result<bool>> Handle(DeleteTransactionTypeCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.Id);
        }
    }
}
