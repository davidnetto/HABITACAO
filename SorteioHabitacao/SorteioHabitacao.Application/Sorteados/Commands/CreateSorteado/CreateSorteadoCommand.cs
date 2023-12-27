using MediatR;
using SorteioHabitacao.Application.Sorteados.Queries.GetSorteios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioHabitacao.Application.Sorteados.Commands.CreateSorteado
{
    public class CreateSorteadoCommand : IRequest<SorteadoVm>
    {
        public string Nome { get; set; }
    }
}
