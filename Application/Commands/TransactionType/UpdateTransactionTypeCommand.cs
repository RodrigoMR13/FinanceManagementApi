using Domain.Common.Models;
using MediatR;

namespace Application.Commands.TransactionType
{
    public class UpdateTransactionTypeCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UpdateTransactionTypeCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
