// Código,
// Descrição,
// Data do Cadastro,
// Valor do Produto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPedidos.Models;
using SistemaPedidos.Models;

public class Produto
{
    public int Id {get; set;}
    public string Descricao { get; set; }
    public DateTime DataCadastro { get; set; }
    public decimal Preco { get; set; }

    public virtual  ICollection<PedidoProduto> PedidosProdutos { get; set; }
}