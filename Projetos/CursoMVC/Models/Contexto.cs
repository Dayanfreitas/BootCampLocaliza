using Microsoft.EntityFrameworkCore;
namespace CursoMVC.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Categoria> Categorias {get; set;}
        public DbSet<Produto> Produtos {get; set;}

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Cursomvc;Trusted_Connection=True");
        }
    }
}