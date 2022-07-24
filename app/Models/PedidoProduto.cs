using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPedidos.Models;
using SistemaPedidos.Models;

public class PedidoProduto
{
    public int PedidoId {get; set;}
    public int ProdutoId {get; set;}
    public virtual Pedido Pedido { get; set; }
    public virtual Produto Produto { get; set; }
}