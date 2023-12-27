using MediatR;
using SorteioHabitacao.Domain.Entity;
using SorteioHabitacao.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioHabitacao.Application.Sorteados.Commands.UpdateSorteado
{
    public class UpdateSorteadoCommandHandler : IRequestHandler<UpdateSorteadoCommand, int>
    {
        private readonly ISorteadoRepository _sorteadoRepository;

        public UpdateSorteadoCommandHandler(ISorteadoRepository sorteadoRepository)
        {
            _sorteadoRepository = sorteadoRepository;
        }
        public async Task<int> Handle(UpdateSorteadoCommand request, CancellationToken cancellationToken)
        {
            var UpdatedSorteadoEntity = new Sorteado()
            {
                Id = request.Id,
                Nome = request.Nome
            };
            return await _sorteadoRepository.UpdateAsync(request.Id, UpdatedSorteadoEntity);
        }
    }
}
