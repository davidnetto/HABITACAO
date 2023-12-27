
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SorteioHabitacao.Application.Sorteados.Commands.CreateSorteado;
using SorteioHabitacao.Application.Sorteados.Commands.DeleteSorteado;
using SorteioHabitacao.Application.Sorteados.Commands.RealizarSorteio;
using SorteioHabitacao.Application.Sorteados.Commands.UpdateSorteado;
using SorteioHabitacao.Application.Sorteados.Queries.GetSorteadoById;
using SorteioHabitacao.Application.Sorteados.Queries.GetSorteios;
using SorteioHabitacao.Domain.Entity;

namespace SorteioHabitacao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SorteadoController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var sorteados = await Mediator.Send(new GetSorteadoQuery());
            return Ok(sorteados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var sorteado = await Mediator.Send(new GetSorteadoByIdQuery() { SorteadoId = id });
            if(sorteado == null)
            {
                return NotFound();
            }
            return Ok(sorteado);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateSorteadoCommand command)
        {
            var createdSorteado = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdSorteado.Id }, createdSorteado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateSorteadoCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();    
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteSorteadoCommand() { Id = id });
            if(result == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpPost("realizar")]
        public async Task<ActionResult> RealizarSorteio(RealizarSorteioCommand command)
        {
            var createdSorteado = await Mediator.Send(command);
            return Ok(createdSorteado);
        }
    }
}
