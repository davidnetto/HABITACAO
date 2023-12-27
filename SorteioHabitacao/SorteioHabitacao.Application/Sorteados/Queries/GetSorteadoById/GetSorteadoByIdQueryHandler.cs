using AutoMapper;
using MediatR;
using SorteioHabitacao.Application.Sorteados.Queries.GetSorteios;
using SorteioHabitacao.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioHabitacao.Application.Sorteados.Queries.GetSorteadoById
{
    public class GetSorteadoByIdQueryHandler : IRequestHandler<GetSorteadoByIdQuery, SorteadoVm>
    {
        private readonly ISorteadoRepository _sorteadoRepository;
        private readonly IMapper _mapper;

        public GetSorteadoByIdQueryHandler(ISorteadoRepository sorteadoRepository, IMapper mapper)
        {
            _sorteadoRepository = sorteadoRepository;
            _mapper = mapper;
        }
        public async Task<SorteadoVm> Handle(GetSorteadoByIdQuery request, CancellationToken cancellationToken)
        {
            var sorteado = await _sorteadoRepository.GetByIdAsync(request.SorteadoId);
            return _mapper.Map<SorteadoVm>(sorteado);
        }
    }
}
