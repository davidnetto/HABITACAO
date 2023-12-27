using SorteioHabitacao.Application.Common.Mappings;
using SorteioHabitacao.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioHabitacao.Application.Sorteados.Queries.GetSorteios
{
    public class SorteadoVm :IMapFrom<Sorteado>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<string> Geral { get; set; }
        public List<string> Fisico { get; set; }
        public List<string> Idoso { get; set; }

        public List<string> VencedoresIdoso { get; set; }
        public List<string> VencedoresDeficienteFisico { get; set; }
        public List<string> VencedoresGeral { get; set; }
    }
}
