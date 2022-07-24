using AutoMapper;
using SistemaPedidos.Context;
using SistemaPedidos.Models;
using SistemaPedidos.Dto;

namespace SistemaPedidos.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pedido, PedidoDto>();
            CreateMap<Fornecedor, FornecedorDto>();
            CreateMap<Produto, ProdutoDto>();

            CreateMap<PedidoDto, Pedido>();
            CreateMap<FornecedorDto, Fornecedor>();
            CreateMap<ProdutoDto, Produto>();
        }
    }
}
