using AutoMapper;
using MediatR;
using SorteioHabitacao.Application.Sorteados.Commands.CreateSorteado;
using SorteioHabitacao.Application.Sorteados.Queries.GetSorteios;
using SorteioHabitacao.Domain.Entity;
using SorteioHabitacao.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioHabitacao.Application.Sorteados.Commands.RealizarSorteio
{
    public class RealizarSorteioCommandHandler : IRequestHandler<RealizarSorteioCommand, SorteadoVm>
    {
        private readonly ISorteadoRepository _sorteadoRepository;
        private readonly IMapper _mapper;

        public RealizarSorteioCommandHandler(ISorteadoRepository sorteadoRepository, IMapper mapper)
        {
            _sorteadoRepository = sorteadoRepository;
            _mapper = mapper;
        }
        public async Task<SorteadoVm> Handle(RealizarSorteioCommand request, CancellationToken cancellationToken)
        {
            List<string> vencedoresIdoso = SortearVencedores(request.Idoso,1);
            List<string> vencedoresDeficienteFisico = SortearVencedores(request.Fisico,1);
            List<string> vencedoresGeral = SortearVencedores(request.Geral, 3);

            SorteadoVm sorteadoVm = new SorteadoVm
            {
                VencedoresIdoso = vencedoresIdoso,
                VencedoresDeficienteFisico = vencedoresDeficienteFisico,
                VencedoresGeral = vencedoresGeral
            };

            return _mapper.Map<SorteadoVm>(sorteadoVm);
        }

        static List<string> SortearVencedores(List<string> participantes, int quantidadeVencedores)
        {
            List<string> vencedores = new List<string>();
            Random random = new Random();

            while (vencedores.Count < quantidadeVencedores && participantes.Count > 0)
            {
                int indiceVencedor = random.Next(participantes.Count);
                vencedores.Add(participantes[indiceVencedor]);
                participantes.RemoveAt(indiceVencedor);
            }

            return vencedores;
        }
    }
}
