using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;

namespace Test.Mocks;

public class AdministradorVeiculoMock : IVeiculoServico
{
    private static List<Veiculo> veiculos = new List<Veiculo>()
    {
        new Veiculo{
            Id = 1,
            Nome = "Fox",
            Marca = "volkswagen",
            Ano = 2010
        },

        new Veiculo{
            Id = 2,
            Nome = "civic",
            Marca = "honda",
            Ano = 2025
        }
    };

    public void Apagar(Veiculo veiculo)
    {
        var existente = veiculos.Find(v => v.Id == veiculo.Id);
        if (existente != null)
        {
            veiculos.Remove(existente);
        }
    }

    public void Atualizar(Veiculo veiculo)
    {
        var existente = veiculos.Find(v => v.Id == veiculo.Id);

        if (existente != null)
        {
            existente.Nome = veiculo.Nome;
            existente.Marca = veiculo.Marca;
            existente.Ano = veiculo.Ano;
        }

    }

    public Veiculo? BuscaPorId(int id)
    {
        return veiculos.Find(v => v.Id == id);
    }

    public void Incluir(Veiculo veiculo)
    {
        veiculo.Id = veiculos.Count() + 1;
        veiculos.Add(veiculo);
    }

    public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
    {
        return veiculos;
    }
}