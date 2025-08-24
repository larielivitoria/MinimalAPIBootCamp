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
public class AdministradorServicoTest
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
    public void TestandoSalvarAdministrador()
    {
        // Arrange - Todas as variáveis que vamos criar
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "teste1@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        var administradorServico = new AdministradorServico(context);

        // Act - Ação Executar
        administradorServico.Incluir(adm);


        // Assert - Validação dos dados
        Assert.AreEqual(3, administradorServico.Todos(1).Count());

    }

    [TestMethod]
    public void TestandoBuscaPorId()
    {
        // Arrange - Todas as variáveis que vamos criar
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Id = 2;
        adm.Email = "editor2@teste.com";
        adm.Senha = "teste2";
        adm.Perfil = "Editor";

        var administradorServico = new AdministradorServico(context);

        // Act - Ação Executar
        administradorServico.Incluir(adm);
        var admDoBanco = administradorServico.BuscaPorId(adm.Id);


        // Assert - Validação dos dados
        Assert.AreEqual(2, admDoBanco?.Id);

    }

    [TestMethod]
    public void TestandoLogin()
    {
        // Arrange - Todas as variáveis que vamos criar
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador()
        {
            Id = 3,
            Email = "editor3@teste.com",
            Senha = "teste2",
            Perfil = "Adm"
        };

        var administradorServico = new AdministradorServico(context);

         // Act - Ação Executar
        administradorServico.Incluir(adm);

        // Arrange
        var login = new LoginDTO();
        login.Email = "editor3@teste.com";
        login.Senha = "teste2";


        // Act - Ação Executar

        var resultado = administradorServico.Login(login);


        // Assert - Validação dos dados
        Assert.IsNotNull(resultado);
        Assert.AreEqual(adm.Email, resultado.Email);
        Assert.AreEqual(adm.Senha, resultado.Senha);

    }
}