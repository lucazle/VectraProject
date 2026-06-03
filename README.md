# Sistema de Funcionários

API RESTful para gerenciamento de funcionários e departamentos, desenvolvida em C# .NET 8 com Clean Architecture.

## Entidade escolhida

**Funcionário** e **Departamento** - com relacionamento um-para-muitos (um departamento tem muitos funcionários).

## Tecnologias utilizadas

- C# .NET 8
- ASP.NET Core Web API
- Entity Framework Core 8
- MySQL (Pomelo.EntityFrameworkCore.MySql)
- Swagger/OpenAPI (Swashbuckle)
- Docker e Docker Compose

## Como executar o projeto

### Clonando o repositório 

Primeiro, é necessário clonar o repositório para sua máquina local.

```bash
git clone https://github.com/lucazle/VectraProject.git
cd VectraProject
```

### Com Docker (recomendado)

Pré-requisitos: Docker Desktop instalado.

```bash
docker-compose up --build
```
A API estará disponível em: `http://localhost:8080`
Swagger: `http://localhost:8080/swagger`

### Sem Docker

Pré-requisitos: .NET 8 SDK e MySQL instalados.

1. Renomeie o arquivo <br>
   `appsettings.example.json` que está na pasta `SistemaFuncionarios.API` para `appsettings.json`
   
2. Configure sua connection string<br>
   > O arquivo `appsettings.json` está no `.gitignore` por segurança. Use o `appsettings.example.json` como modelo.
  ```
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Port=3306;Database=sistema_funcionarios;User=SEUUSERAQUI;Password=SUASENHAAQUI;"
}
```
  Substituira o campo `SEUUSERAQUI` e `SUASENHAAQUI` pelo user e senha do seu MySQL, respectivamente.

   
3. Rode a aplicação:

```bash
dotnet run --project SistemaFuncionarios.API
```

## Arquitetura

