using Application.Commands.TransactionType;
using Application.Queries;
using Application.Queries.TransactionType;
using Domain.Common.Models;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManagementApi.Controllers
{
    [ApiController]
    [Route("api/transaction_types")]
    public class TransactionTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TransactionTypeController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllTransactionTypeQuery();
            var result = await _mediator.Send(query);

            if (result.Data is IEnumerable<TransactionType> list && !list.Any())
                return NoContent();

            return Ok(result.Data);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetTransactionTypeByIdQuery(id);
            var result = await _mediator.Send(query);
            if (!result.Success)
                return NotFound(result.Error);

            if (result.Data is TransactionType tt && tt is null)
                return NoContent();

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransactionTypeCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
                return NotFound(result.Error);

            return CreatedAtAction(nameof(GetById), new { id = result.Data!.Id }, result.Data);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTransactionTypeCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID do corpo e da URL não coincidem.");

            var result = await _mediator.Send(command);

            if (!result.Success)
                return NotFound(result.Error);

            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteTransactionTypeCommand(id));

            if (!result.Success)
                return NotFound(result.Error);

            return NoContent();
        }
    }
}
