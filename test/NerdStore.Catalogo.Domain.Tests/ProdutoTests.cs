using NerdStore.Core.DomainObjects;
using System;
using Xunit;

namespace NerdStore.Catalogo.Domain.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_Validar_ValidacoesDevemRetornarExceptions()
        {
            //Arrange & Act & Assert
            var ex = Assert.Throws<DomainException>(testCode: () =>
                 new Produto(string.Empty, "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1))
            );

            Assert.Equal(expected: "O campo Nome do produto não pode estar vazio", actual:ex.Message);

            ex = Assert.Throws<DomainException>(testCode: () =>
                 new Produto("Nome", string.Empty, false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1))
            );

            Assert.Equal(expected: "O campo Descrição do produto não pode estar vazio", actual: ex.Message);

            ex = Assert.Throws<DomainException>(testCode: () =>
                 new Produto("Nome", "Descricao", false, 0, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1))
            );

            Assert.Equal(expected: "O campo Valor do produto não pode ser menor ou igual a Zero", actual: ex.Message);

            ex = Assert.Throws<DomainException>(testCode: () =>
                 new Produto("Nome", "Descricao", false, 100, Guid.Empty, DateTime.Now, "Imagem", new Dimensoes(1, 1, 1))
            );

            Assert.Equal(expected: "O campo CategoriaId do produto não pode estar vazio", actual: ex.Message);

            ex = Assert.Throws<DomainException>(testCode: () =>
                 new Produto("Nome", "Descricao", false, 100, Guid.NewGuid(), DateTime.Now, string.Empty, new Dimensoes(1, 1, 1))
            );

            Assert.Equal(expected: "O campo Imagem do produto não pode estar vazio", actual: ex.Message);

        }
    }
}
