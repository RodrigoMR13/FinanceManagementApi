using Domain.Common.Models;
using MediatR;

namespace Application.Commands.TransactionType
{
    public class CreateTransactionTypeCommand : IRequest<Result<Domain.Entities.TransactionType>>
    {
        public string Name { get; set; }

        public CreateTransactionTypeCommand(string name)
        {
            Name = name;
        }
    }
}
