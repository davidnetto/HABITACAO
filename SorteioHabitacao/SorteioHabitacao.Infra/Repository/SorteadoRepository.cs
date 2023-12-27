using Microsoft.EntityFrameworkCore;
using SorteioHabitacao.Domain.Entity;
using SorteioHabitacao.Domain.Repository;
using SorteioHabitacao.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioHabitacao.Infra.Repository
{
    public class SorteadoRepository : ISorteadoRepository
    {
        private readonly SorteadoDbContext _sorteadoDbContext;

        public SorteadoRepository(SorteadoDbContext sorteadoDbContext)
        {
            _sorteadoDbContext = sorteadoDbContext;
        }
        public async Task<Sorteado> CreateAsync(Sorteado sorteado)
        {
            await _sorteadoDbContext.Sorteados.AddAsync(sorteado);
            await _sorteadoDbContext.SaveChangesAsync();
            return sorteado;
        }

        public async Task<int> DeleteAsync(int id)
        {
           return await _sorteadoDbContext.Sorteados.Where(model => model.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<Sorteado>> GetAllSorteadosAsync()
        {
            return await _sorteadoDbContext.Sorteados.ToListAsync();
        }

        public async Task<Sorteado> GetByIdAsync(int id)
        {
            return await _sorteadoDbContext.Sorteados.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Sorteado sorteado)
        {
            return await _sorteadoDbContext.Sorteados
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                .SetProperty(m => m.Nome, sorteado.Nome)
                );
        }
    }
}
