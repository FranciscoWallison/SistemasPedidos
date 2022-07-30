// Código,
// Descrição,
// Data do Cadastro,
// Valor do Produto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPedidos.Models;
using SistemaPedidos.Models;

public class Pedido
{
    public int Id {get; set;}
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataCadastro { get; set; }
    public int QtdProduto { get; set; }
    public decimal Preco { get; set; }
    public int FornecedorId { get; set; }

    public virtual Fornecedor Fornecedor { get; set; }
    public virtual ICollection<PedidoProduto> PedidosProdutos { get; set; }
    // public virtual ICollection<Produto> Produto { get; set; }
}