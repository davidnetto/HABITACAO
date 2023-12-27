using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioHabitacao.Application.Sorteados.Queries.GetSorteios
{
    public class GetSorteadoQuery :IRequest<List<SorteadoVm>>
    {
    }

    //public record GetSorteadoQuery : IRequest<List<SorteadosVm>>
    
}
