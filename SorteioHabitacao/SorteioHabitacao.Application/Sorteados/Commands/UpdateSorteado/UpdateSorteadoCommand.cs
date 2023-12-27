using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioHabitacao.Application.Sorteados.Commands.UpdateSorteado
{
    public class UpdateSorteadoCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
