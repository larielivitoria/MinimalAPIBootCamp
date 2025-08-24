using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Infraestrutura.Db;
using MinimalApi.Dominio.Servicos;
using System.Reflection;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.KeyPerFile;
using MinimalApi.DTOs;


namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoServicoTest
{
    private DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(path: Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

        var builder = new ConfigurationBuilder()
        .SetBasePath(path ?? Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

        var configuration = builder.Build();

        return new DbContexto(configuration);
    }

    [TestMethod]
    public void TestandoSalvarVeiculo()
    {
        // Arrange - Todas as variáveis que vamos criar
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

        var v = new Veiculo();
        v.Id = 1;
        v.Nome = "monza";
        v.Marca = "chevrolet";
        v.Ano = 1993;

        var veiculoServico = new VeiculoServico(context);

        // Act - Ação Executar
        veiculoServico.Incluir(v);


        // Assert - Validação dos dados
        Assert.AreEqual(4, veiculoServico.Todos(1).Count());

    }

    [TestMethod]
    public void TestandoBuscaPorId()
    {
        // Arrange - Todas as variáveis que vamos criar
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

        var v = new Veiculo();
        v.Id = 2;
        v.Nome = "ka";
        v.Marca = "ford";
        v.Ano = 2007;

        var v2 = new Veiculo();
        v2.Id = 3;
        v2.Nome = "chevette";
        v2.Marca = "chevrolet";
        v2.Ano = 1993;

        var veiculoServico = new VeiculoServico(context);

        // Act - Ação Executar
        veiculoServico.Incluir(v);
        veiculoServico.Incluir(v2);
        var vDoBanco = veiculoServico.BuscaPorId(v.Id);
        var vDoBanco2 = veiculoServico.BuscaPorId(v2.Id);


        // Assert - Validação dos dados
        Assert.AreEqual(2, vDoBanco?.Id);
        Assert.AreEqual(3, vDoBanco2?.Id);

    }

    [TestMethod]
    public void TestandoAtualizarVeiculo()
    {
        // Arrange - Todas as variáveis que vamos criar
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

        var v = new Veiculo();
        v.Id = 4;
        v.Nome = "corolla";
        v.Marca = "toyota";
        v.Ano = 2012;

        var veiculoServico = new VeiculoServico(context);

        // Act - Ação Executar
        veiculoServico.Incluir(v);

        // Recupera do banco de dados
        var corolla = veiculoServico.BuscaPorId(v.Id);

        // Assert - Validação dos dados, verifica se o veículo foi realmente salvo.
        Assert.IsNotNull(corolla);
        Assert.AreEqual("corolla", corolla.Nome);
        Assert.AreEqual("toyota", corolla.Marca);
        Assert.AreEqual(2012, corolla.Ano);

        //Edição dos dados
        v.Nome = "E36";
        v.Marca = "BMW";
        v.Ano = 1993;

        // Novo Act
        veiculoServico.Atualizar(v);
        var veiculoAtualizado = veiculoServico.BuscaPorId(v.Id);

        // Assert - Validação dos dados, verifica se realmente foi atualizado.
        Assert.IsNotNull(veiculoAtualizado);
        Assert.AreEqual("E36", veiculoAtualizado.Nome);
        Assert.AreEqual("BMW", veiculoAtualizado.Marca);
        Assert.AreEqual(1993, veiculoAtualizado.Ano);


    }

    [TestMethod]
    public void TestandoApagarVeiculo()
    {
        // Arrange - Todas as variáveis que vamos criar
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

        var v = new Veiculo();
        v.Id = 5;
        v.Nome = "lancer";
        v.Marca = "mitsubishi";
        v.Ano = 2020;


        var veiculoServico = new VeiculoServico(context);

        // Act - Ação Executar
        veiculoServico.Incluir(v);
        var lancer = veiculoServico.BuscaPorId(5);

        // Assert - Validação dos dados, verifica se o veiculo foi realmente adicionado
        Assert.IsNotNull(lancer);
        Assert.AreEqual("lancer", lancer.Nome);
        Assert.AreEqual("mitsubishi", lancer.Marca);
        Assert.AreEqual(2020, lancer.Ano);

        // Novo Act 
        veiculoServico.Apagar(v);

        // Verifica no banco de dados se realmente foi apagado
        var apagado = veiculoServico.BuscaPorId(5);

        // Assert - Validação dos dados
        Assert.IsNull(apagado);

    }

}