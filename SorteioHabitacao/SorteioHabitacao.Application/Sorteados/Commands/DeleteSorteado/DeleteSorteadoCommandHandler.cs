using MediatR;
using SorteioHabitacao.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioHabitacao.Application.Sorteados.Commands.DeleteSorteado
{
    public class DeleteSorteadoCommandHandler : IRequestHandler<DeleteSorteadoCommand, int>
    {
        private readonly ISorteadoRepository _sorteadoRepository;

        public DeleteSorteadoCommandHandler(ISorteadoRepository sorteadoRepository)
        {
            _sorteadoRepository = sorteadoRepository;
        }
        public async Task<int> Handle(DeleteSorteadoCommand request, CancellationToken cancellationToken)
        {
            return await _sorteadoRepository.DeleteAsync(request.Id);
        }
    }
}
