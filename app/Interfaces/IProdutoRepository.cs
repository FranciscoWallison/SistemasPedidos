using SistemaPedidos.Dto;
using SistemaPedidos.Models;

namespace SistemaPedidos.Interfaces
{
    public interface IProdutoRepository
    {
        // ICollection<Fornecedor> getALL();
        // Fornecedor get(int id);
        // bool Create(Fornecedor fornecedor);
        // bool Update(Fornecedor fornecedor);
        // bool Delete(Fornecedor fornecedor);
        // bool Save();
        ICollection<Produto> getProduto(int pedidoId);
    }
}
