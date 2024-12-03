using Microsoft.EntityFrameworkCore;
using ConectaCliente.Models;

namespace ConectaCliente.Data
{
    public class AppCont : DbContext
    {
        public AppCont(DbContextOptions<AppCont> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
