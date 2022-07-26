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

        public ICollection<Produto> getALL()
        {
            return _context.Produtos.OrderBy(f => f.Id).ToList();
        }

        public Produto get(int Id)
        {   

            var produto = _context.Produtos.Find(Id);
            _context
                .Entry(produto)
                .Collection("PedidosProdutos")
                .Load();

            return produto;
        }
        
        public bool Create(Produto produto)
        {
            produto.DataCadastro = DateTime.Now;
            _context.Add(produto);
            return Save();
        }
        public bool Update(Produto produto)
        {
            _context.Update(produto);
            return Save();
        }
        public bool Delete(int Id)
        {
           var produto = _context.Produtos.Find(Id);
            _context.Remove(produto);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Exists(int Id)
        {
            return _context.Produtos.Any(p => p.Id == Id);
        }
    }
}