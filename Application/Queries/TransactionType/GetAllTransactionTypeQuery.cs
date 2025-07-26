using Domain.Common.Models;
using MediatR;

namespace Application.Queries.TransactionType
{
    public class GetAllTransactionTypeQuery : IRequest<Result<IEnumerable<Domain.Entities.TransactionType>>>
    {

    }
}
