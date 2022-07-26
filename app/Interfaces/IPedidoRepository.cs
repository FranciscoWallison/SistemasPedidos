using SistemaPedidos.Dto;
using SistemaPedidos.Models;

namespace SistemaPedidos.Interfaces
{
    public interface IPedidoRepository
    {
        ICollection<Pedido> getALL();
        PedidoDto get(int id);
        bool Create(int fornecedorId, List<Produto> produto, Pedido pedido);
        bool Update(Pedido pedido);
        bool Delete(int pedidoId);
        bool Save();

        bool Exists(int Id);

        bool AddProduto(Produto produto, Pedido pedido);
        bool RemoveProduto(Produto produto, Pedido pedido);
    }
}
