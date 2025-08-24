using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoTest
{
    
    [TestMethod]
    public void TestarVeiculo()
    {
        // Arrange - Todas as variáveis que vamos criar
        var veiculo = new Veiculo();

        // Act - Ação Executar
        veiculo.Id = 6;
        veiculo.Nome = "bmw";
        veiculo.Marca = "e36";
        veiculo.Ano = 1993;

        // Assert - Validação dos dados
        Assert.AreEqual(6, veiculo.Id);
        Assert.AreEqual("bmw", veiculo.Nome);
        Assert.AreEqual("e36", veiculo.Marca);
        Assert.AreEqual(1993, veiculo.Ano);
    }
}
