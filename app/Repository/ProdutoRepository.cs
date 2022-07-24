using SistemaPedidos.Context;
using SistemaPedidos.Dto;
using SistemaPedidos.Interfaces;
using SistemaPedidos.Models;

namespace SistemaPedidos.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly MovieContext _context;

        public ProdutoRepository(MovieContext context)
        {
            _context = context;
        }

        public ICollection<Produto> getProduto(int pedidoId)
        {
            var pedidosProdutos = _context.PedidosProdutos.Where(p => p.PedidoId == pedidoId).ToList();

            List<Produto> produtos = new List<Produto>();
            foreach (PedidoProduto pedidoProduto in pedidosProdutos)
            {
                // validar se existe os produtos                
                produtos.Add(pedidoProduto.Produto);
            }

            return produtos;
        }
    }
}