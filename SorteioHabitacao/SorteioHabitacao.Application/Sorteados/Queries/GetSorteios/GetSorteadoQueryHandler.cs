using AutoMapper;
using MediatR;
using SorteioHabitacao.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioHabitacao.Application.Sorteados.Queries.GetSorteios
{
    public class GetSorteadoQueryHandler : IRequestHandler<GetSorteadoQuery, List<SorteadoVm>>
    {
        private readonly ISorteadoRepository _sorteadoRepository;
        private readonly IMapper _mapper;

        public GetSorteadoQueryHandler(ISorteadoRepository sorteadoRepository, IMapper mapper)
        {
            _sorteadoRepository = sorteadoRepository;
            _mapper = mapper;
        }

  
        public async Task<List<SorteadoVm>> Handle(GetSorteadoQuery request, CancellationToken cancellationToken)
        {
            var sorteados = await _sorteadoRepository.GetAllSorteadosAsync();
            //var sorteadosList = sorteados.Select(x => new SorteadoVm 
            //    { Id = x.Id, Nome = x.Nome }).ToList();

            var sorteadosList = _mapper.Map<List<SorteadoVm>>(sorteados);
            return sorteadosList;
        }
    }
}
