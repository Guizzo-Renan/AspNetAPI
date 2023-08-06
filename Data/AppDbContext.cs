// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<ProdutoAuxiliar> ProdutosAuxiliares { get; set; }
    public DbSet<Especificacao> Especificacoes { get; set; }
    
    public DbSet<Estoque> Estoques { get; set; }
}