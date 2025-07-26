using Domain.Common.Models;
using MediatR;

namespace Application.Commands.TransactionType
{
    public class DeleteTransactionTypeCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public DeleteTransactionTypeCommand(int id)
        {
            Id = id;
        }
    }
}
