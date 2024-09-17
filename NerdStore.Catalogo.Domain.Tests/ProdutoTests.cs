using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain.Tests;

public class ProdutoTests
{
    [Fact]
    public void Produto_Validar_ValidacoesDevemRetornarExceptions()
    {
        // Arrange, Act & Assert

        // Testando a valida��o do campo Nome
        var ex = Assert.Throws<DomainException>(testCode: () =>
            new Produto(string.Empty, "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)));
        Assert.Equal(expected: "O campo Nome do produto n�o pode estar vazio", actual: ex.Message);

        // Testando a valida��o do campo Descricao
        ex = Assert.Throws<DomainException>(() =>
            new Produto("Nome", string.Empty, false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)));
        Assert.Equal("O campo Descricao do produto n�o pode estar vazio", ex.Message);

        // Testando a valida��o do campo Valor
        ex = Assert.Throws<DomainException>(() =>
            new Produto("Nome", "Descricao", false, 0, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)));
        Assert.Equal("O campo Valor do produto n�o pode ser menor ou igual a 0", ex.Message);

        // Testando a valida��o do campo CategoriaId
        ex = Assert.Throws<DomainException>(() =>
            new Produto("Nome", "Descricao", false, 100, Guid.Empty, DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)));
        Assert.Equal("O campo CategoriaId do produto n�o pode estar vazio", ex.Message);

        // Testando a valida��o do campo Imagem
        ex = Assert.Throws<DomainException>(() =>
            new Produto("Nome", "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, string.Empty, new Dimensoes(1, 1, 1)));
        Assert.Equal("O campo Imagem do produto n�o pode estar vazio", ex.Message);
    }
}