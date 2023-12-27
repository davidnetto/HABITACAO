using SorteioHabitacao.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioHabitacao.Domain.Repository
{
    public interface ISorteadoRepository
    {
        Task<List<Sorteado>> GetAllSorteadosAsync();
        Task<Sorteado> GetByIdAsync(int id);
        Task<Sorteado> CreateAsync(Sorteado sorteado);
        Task<int> UpdateAsync(int id, Sorteado sorteado);
        Task<int> DeleteAsync(int id);
    }
}
