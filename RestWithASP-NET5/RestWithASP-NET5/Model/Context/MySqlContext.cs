using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {
                
        }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
            
        }
        public DbSet<UsuarioModel> UsuarioModels { get; set; }
        public DbSet<LivrosModel> LivrosModels { get; set; }
    }
}
