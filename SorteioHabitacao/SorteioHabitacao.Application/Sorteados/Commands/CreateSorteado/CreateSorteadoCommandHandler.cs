using AutoMapper;
using MediatR;
using SorteioHabitacao.Application.Sorteados.Queries.GetSorteios;
using SorteioHabitacao.Domain.Entity;
using SorteioHabitacao.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioHabitacao.Application.Sorteados.Commands.CreateSorteado
{
    public class CreateSorteadoCommandHandler : IRequestHandler<CreateSorteadoCommand, SorteadoVm>
    {
        private readonly ISorteadoRepository _sorteadoRepository;
        private readonly IMapper _mapper;

        public CreateSorteadoCommandHandler(ISorteadoRepository sorteadoRepository, IMapper mapper)
        {
            _sorteadoRepository = sorteadoRepository;
            _mapper = mapper;
        }
        public async Task<SorteadoVm> Handle(CreateSorteadoCommand request, CancellationToken cancellationToken)
        {
            var sorteadoEntity = new Sorteado() { Nome= request.Nome };
            var Result = await _sorteadoRepository.CreateAsync(sorteadoEntity);
            return _mapper.Map<SorteadoVm>(Result);
        }
    }
}
