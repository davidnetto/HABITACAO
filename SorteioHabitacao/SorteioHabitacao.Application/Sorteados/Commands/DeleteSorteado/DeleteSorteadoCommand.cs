using MediatR;
using SorteioHabitacao.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioHabitacao.Application.Sorteados.Commands.DeleteSorteado
{
    public class DeleteSorteadoCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
