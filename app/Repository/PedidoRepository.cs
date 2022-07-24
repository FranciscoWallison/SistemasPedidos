using AutoMapper;
using SistemaPedidos.Context;
using SistemaPedidos.Dto;
using SistemaPedidos.Interfaces;
using SistemaPedidos.Models;

namespace SistemaPedidos.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public PedidoRepository(MovieContext context, IMapper mapper)
        {
            _context = context;
             _mapper = mapper;
        }

        public ICollection<Pedido> getALL()
        {
           var pedidos = _context.Pedidos.OrderBy(p => p.Id).ToList();
            return pedidos;
        }

        public Pedido get(int Id)
        {   

            var pedidosN = _context.Pedidos.Find(Id);
            _context
                .Entry(pedidosN)
                .Reference("Fornecedor")
                .Load();

           _context
                .Entry(pedidosN)
                .Collection("PedidosProdutos")
                .Load();

            return pedidosN;
        }

        public bool Create(int fornecedorId, List<Produto> produtos, Pedido newPedido)
        {
            newPedido.FornecedorId = fornecedorId;
            _context.Add(newPedido);
            _context.SaveChanges();
            
            foreach(Produto p in produtos)
            {
                var pedidosProdutos = new PedidoProduto()
                {
                    
                    ProdutoId = p.Id,
                    PedidoId = newPedido.Id,
                };

                _context.Add(pedidosProdutos);
            }

            return Save();
        }

        public bool Update(Pedido pedido)
        {
            _context.Update(pedido);
            return Save();
        }

        public bool Delete(int pedidoId)
        {
            var pedidos = _context.Pedidos.Find(pedidoId);
            _context.Remove(pedidos);
            
            var pedidosProdutos = _context.PedidosProdutos.Where(a => a.PedidoId == pedidoId).ToList();
            _context.RemoveRange(pedidosProdutos);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Exists(int Id)
        {
            return _context.Pedidos.Any(p => p.Id == Id);
        }


        
    }
}