using SistemaPedidos.Context;
using SistemaPedidos.Models;

namespace SistemaPedidos
{
    public class Seed
    {
        private readonly MovieContext MovieContext;
        public Seed(MovieContext context)
        {
            this.MovieContext = context;
        }
        public void SeedMovieContext()
        {
            if (!MovieContext.PedidosProdutos.Any())
            {
                var pedidosProdutos = new List<PedidoProduto>()
                {
                    new PedidoProduto()
                    {
                        Pedido = new Pedido()
                        {
                            Descricao = "Eletrônicos",
                            DataCadastro = new DateTime(1903,1,1),
                            QtdProduto = 2,
                            Preco = 10,
                            Fornecedor = new Fornecedor()
                            {
                                Nome = "Teste",
                                RazaoSocial = "Açougue União",
                                Email = "contato@açougueunião.com",
                                UF = "SP",
                                CNPJ = "66.397.633/0001-93"
                            },
                            PedidosProdutos = new List<PedidoProduto>()
                            {
                                new PedidoProduto { 
                                    Produto = new Produto()
                                        {
                                           Descricao = "TV",
                                            DataCadastro = new DateTime(1903,1,1),
                                            Preco = 2000000
                                        }
                                }
                            }
                        },
                        Produto = new Produto()
                        {
                            Descricao = "Video Game",
                            DataCadastro = new DateTime(1903,1,1),
                            Preco = 5000000
                        }
                    },
                };
                MovieContext.PedidosProdutos.AddRange(pedidosProdutos);
                MovieContext.SaveChanges();
            }
        }
    }
}
