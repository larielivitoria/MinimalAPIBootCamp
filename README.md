# Trabalhando com ASP.NET Minimal API

## Réplica do Projeto MinimalAPI do Bootcamp GFT

#### Foram horas de concentração, aprendizado e superação, enfrentei erros, bugs e falhas, mas com determinação e busca por informação, consegui corrigir todos os imprevistos. Aprendi a como configurar o Swagger, como adicionar GET/PUT/POST/DELETE, vimos um pouco de Arquitetura de Software, Estrutura do Projeto, Validação do administrador com login e senha no banco de dados, Validação do veículo ao cadastrar e atualizar, Interfaces, Banco de Dados, DTOs, Entity Framework, Migrations, CRUD, Token Jwt, Autenticação e Autorização com Restrição de Acesso, e a como executar os Testes na Aplicação.
#### Tempo Total de Dedicação: 21h30min
### Conquistas:
#### - Todos os bugs corrigidos.
#### - Todos os testes finalizados com sucesso.
#### - Projeto funcionando como esperado.

### Códigos criados por mim, conforme os desafios:

#### - Teste Veículo (Test/domain/entidades/veiculoTest.cs)
#### - Teste Login de Administrador (Test/domain/servicos/administradorServicoTest.cs - Método TestandoLogin)
#### - Teste Salvar Veículo (Test/domain/servicos/veiculoServicoTest.cs - Método TestandoSalvarVeiculo)
#### - Teste Buscar Veículo por Id (Test/domain/servicos/veiculoServicoTest.cs - Método TestandoBuscarPorId)
#### - Teste Atualizar Veículo - Garante que o método "Incluir" realmente salva no banco de dados,e garante que o método "Atualizar" persiste as alterações no banco de dados. (Test/domain/servicos/veiculoServicoTest.cs - Método TestandoAtualizarVeiculo)
#### - Teste Apagar Veículo - Antes de apagar garante que o veículo existe, após apagar garante que o veículo não existe mais. (Test/domain/servicos/veiculoServicoTest.cs - Método TestandoApagarVeiculo)
#### - Veiculo Serviço Mock (Test/Mocks/VeiculoServicoMock.cs)

### OBS: Se der erro no dotnet test, no método "Salvar Veículo", rode novamente o test, as vezes ele buga sozinho o número de veículos na lista, é só rodar novamente.
