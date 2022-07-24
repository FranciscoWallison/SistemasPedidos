namespace SistemaPedidos.Dto
{
    public class PedidoDto
    {
        public int Id {get; set;}
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
        public int QtdProduto { get; set; }
        public decimal Preco { get; set; }
        public int FornecedorId { get; set; }

        public FornecedorDto Fornecedor { get; set; }
        public List<ProdutoDto> Produtos { get; set; }
    }
}