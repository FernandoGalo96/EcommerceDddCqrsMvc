using AutoMapper;
using NerdStore.Catalogo.Domain;
using NerdStore.Catologo.Application.ViewModels;

namespace NerdStore.Catalogo.Data.Mapping;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        CreateMap<Categoria, CategoriaViewModel>();

        CreateMap<Produto, ProdutoViewModel>().ForMember(d => d.Largura, o => o.MapFrom(s => s.Dimensoes.Largura))
                .ForMember(d => d.Altura, o => o.MapFrom(s => s.Dimensoes.Altura))
                .ForMember(d => d.Profundidade, o => o.MapFrom(s => s.Dimensoes.Profundidade));
    }
}