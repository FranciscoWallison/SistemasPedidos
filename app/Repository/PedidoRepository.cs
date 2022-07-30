using AutoMapper;
using SistemaPedidos.Context;
using SistemaPedidos.Dto;
using SistemaPedidos.Interfaces;
using SistemaPedidos.Models;
using Microsoft.EntityFrameworkCore;

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
           var pedidos = _context.Pedidos
           .Include("Fornecedor")
           .OrderBy(p => p.Id).ToList();
                
            return pedidos;
        }

        public PedidoDto get(int Id)
        {   

            var pedidosN = _context.Pedidos
            .Where(p => p.Id == Id)
            .Include("Fornecedor")
            .Include("PedidosProdutos.Produto")
            .FirstOrDefault();

            // converte produtos
            List<Produto> produtosN = new List<Produto>();
            foreach(PedidoProduto p in pedidosN.PedidosProdutos)
            {
               produtosN.Add(p.Produto);
            }
            var produtos =  _mapper.Map<List<ProdutoDto>>(produtosN);


            var peidoMap = _mapper.Map<PedidoDto>(pedidosN);
            peidoMap.Produtos = produtos;
            return peidoMap;
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

        public bool AddProduto(Produto produto, Pedido pedido)
        {
            return false;
        }

        public bool RemoveProduto(Produto produto, Pedido pedido)
        {
            return false;
        }
    }
}