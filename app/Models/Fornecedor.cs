// Razão Social,
// CNPJ,
// UF,
// Email Contato e
// Nome Contato;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaPedidos.Models;
using SistemaPedidos.Models;

public class Fornecedor
{
    public int Id {get; set;}
    public String Nome { get; set; }
    public String RazaoSocial { get; set; }
    public String Email { get; set; }
    public String UF { get; set; }
    public String CNPJ { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; }
}