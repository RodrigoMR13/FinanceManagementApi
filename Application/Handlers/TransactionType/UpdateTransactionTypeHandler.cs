using Application.Commands.TransactionType;
using Domain.Common.Models;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.TransactionType
{
    public class UpdateTransactionTypeHandler : IRequestHandler<UpdateTransactionTypeCommand, Result<bool>>
    {
        private readonly ITransactionTypeRepository _repository;

        public UpdateTransactionTypeHandler(ITransactionTypeRepository transactionTypeRepository)
        {
            _repository = transactionTypeRepository;
        }

        public async Task<Result<bool>> Handle(UpdateTransactionTypeCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAsync(new Domain.Entities.TransactionType() { Id = request.Id, Name = request.Name });
        }
    }
}
