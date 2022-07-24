namespace SistemaPedidos.Dto
{
    public class FornecedorDto
    {
        public int Id {get; set;}
        public String Nome { get; set; }
        public String RazaoSocial { get; set; }
        public String Email { get; set; }
        public String UF { get; set; }
        public String CNPJ { get; set; }

        public List<PedidoDto> Pedidos { get; set; }
    }
}