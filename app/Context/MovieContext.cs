using Microsoft.EntityFrameworkCore;
using System.Linq;
using SistemaPedidos.Models;

namespace SistemaPedidos.Context
{
     public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options)  : base(options)
        {
                
        }
        
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Fornecedor> Fornecedores { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<PedidoProduto> PedidosProdutos { get; set; }
        // public DbSet<FornecedorPedido> FornecedoresPedidos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

                // modelBuilder.Entity<FornecedorPedido>()
                //         .HasKey(pp => new { pp.PedidoId, pp.FornecedorId });
                // modelBuilder.Entity<FornecedorPedido>()
                //         .HasOne(p => p.Pedido)
                //         .WithMany(fp => fp.FornecedoresPedidos)
                //         .HasForeignKey(p => p.PedidoId);
                // modelBuilder.Entity<FornecedorPedido>()
                //         .HasOne(fo => fo.Fornecedor)
                //         .WithMany(fp => fp.FornecedoresPedidos)
                //         .HasForeignKey(f => f.FornecedorId);

                modelBuilder.Entity<Fornecedor>()
                        .HasMany(c => c.Pedidos)
                        .WithOne(e => e.Fornecedor);

                modelBuilder.Entity<Pedido>()
                        .HasOne(p => p.Fornecedor)
                        .WithMany(b => b.Pedidos)
                        .HasForeignKey(x => x.FornecedorId);

                modelBuilder.Entity<PedidoProduto>()
                        .HasOne(p => p.Produto)
                        .WithMany(b => b.PedidosProdutos)
                        .HasForeignKey(x => x.ProdutoId);
                modelBuilder.Entity<PedidoProduto>()
                        .HasOne(p => p.Pedido)
                        .WithMany(b => b.PedidosProdutos)
                        .HasForeignKey(x => x.PedidoId);


                modelBuilder.Entity<PedidoProduto>()
                        .HasKey(pp => new { pp.PedidoId, pp.ProdutoId });
                modelBuilder.Entity<PedidoProduto>()
                        .HasOne(p => p.Pedido)
                        .WithMany(pp => pp.PedidosProdutos)
                        .HasForeignKey(p => p.PedidoId);
                modelBuilder.Entity<PedidoProduto>()
                        .HasOne(po => po.Produto)
                        .WithMany(pp => pp.PedidosProdutos)
                        .HasForeignKey(c => c.ProdutoId);
        }
    }
}