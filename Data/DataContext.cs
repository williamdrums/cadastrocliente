

using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Estado> Estados { get; set; }

        public DbSet<Cidade> Cidades { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }
    }
}