using Domain.Common.Models;
using MediatR;

namespace Application.Queries.TransactionType
{
    public class GetTransactionTypeByIdQuery : IRequest<Result<Domain.Entities.TransactionType?>>
    {
        public int Id { get; set; }

        public GetTransactionTypeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
