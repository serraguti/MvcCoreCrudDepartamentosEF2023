using Microsoft.EntityFrameworkCore;
using MvcCoreCrudDepartamentosEF.Models;

namespace MvcCoreCrudDepartamentosEF.Data
{
    public class DepartamentosContext: DbContext
    {
        public DepartamentosContext(DbContextOptions<DepartamentosContext> options)
            : base(options) { }

        public DbSet<Departamento> Departamentos { get; set; }
    }
}
