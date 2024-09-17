using NerdStore.Catologo.Application.ViewModels;

namespace NerdStore.Catologo.Application.Services;

public interface IProdutoAppService : IDisposable
{
    Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo);

    Task<ProdutoViewModel> ObterPorId(Guid id);

    Task<IEnumerable<ProdutoViewModel>> ObterTodos();

    Task<IEnumerable<CategoriaViewModel>> ObterCategorias();

    Task AdicionarProduto(ProdutoViewModel produtoDto);

    Task AtualizarProduto(ProdutoViewModel produtoDto);

    Task<ProdutoViewModel> DebitarEstoque(Guid id, int quantidade);

    Task<ProdutoViewModel> ReporEstoque(Guid id, int quantidade);
}