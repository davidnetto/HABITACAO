using Microsoft.EntityFrameworkCore;
using SorteioHabitacao.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioHabitacao.Infra.Data
{
    public class SorteadoDbContext : DbContext
    {
        public SorteadoDbContext(DbContextOptions<SorteadoDbContext> dbContextOptions) 
            : base(dbContextOptions)
        {
          
        }

        public DbSet<Sorteado> Sorteados { get; set; }
    }
}
