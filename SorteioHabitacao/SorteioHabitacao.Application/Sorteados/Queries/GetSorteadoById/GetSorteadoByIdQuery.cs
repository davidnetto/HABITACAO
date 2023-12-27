using MediatR;
using SorteioHabitacao.Application.Sorteados.Queries.GetSorteios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioHabitacao.Application.Sorteados.Queries.GetSorteadoById
{
    public class GetSorteadoByIdQuery :IRequest<SorteadoVm>
    {
        public int SorteadoId { get; set; }
    }
}
