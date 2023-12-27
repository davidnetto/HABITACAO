using MediatR;
using SorteioHabitacao.Application.Sorteados.Queries.GetSorteios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioHabitacao.Application.Sorteados.Commands.RealizarSorteio
{
    public class RealizarSorteioCommand : IRequest<SorteadoVm>
    {
        public List<string> Geral { get; set; }
        public List<string> Idoso { get; set; }
        public List<string> Fisico { get; set; }
    }
}
