# Sistema de Funcionários

É uma API que gerencia funcionários e departamentos de uma empresa. Você pode cadastrar, listar, editar e deletar os dois. Um funcionário pertence a um departamento.

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
cd VectraProject/
```

### Com Docker (recomendado)

Pré-requisitos: [Docker Desktop](https://www.docker.com/products/docker-desktop/) instalado.

1. Crie um arquivo `.env` na raiz do projeto utilizando o `.env.example` como modelo.
```bash
cp .env.example .env
```
2. Configure os valores das variáveis de ambiente conforme necessário.
3. Execute os containers:
```bash
docker-compose up --build
```
A API estará disponível em: `http://localhost:8080`<br>
Swagger: `http://localhost:8080/swagger`

### Sem Docker

Pré-requisitos: [.NET 8 SDK](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0) e [MySQL](https://dev.mysql.com/downloads/installer/) instalados.

1. Crie um arquivo `appsettings.json` na pasta `SistemasFuncionarios.API` do projeto utilizando o `appsettings.example.json` como modelo. <br>
```
cp appsettings.example.json appsettings.json
```
2. Configure sua connection string conforme necessário<br>
  ```
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Port=3306;Database=sistema_funcionarios;User=SEUUSERAQUI;Password=SUASENHAAQUI;"
}
```
Substituira o campo `SEUUSERAQUI` e `SUASENHAAQUI` pelo user e senha do seu MySQL, respectivamente.

   
3. Execute a aplicação:

```bash
dotnet run --project SistemaFuncionarios.API
```

## Arquitetura

O projeto foi estruturado seguindo os príncipios da Clean Architecture, com separação de responsabilidade entre camadas da aplicação:

- **Domain** — Contém as entidades, interfaces e excecões. É a camada central da aplicação e não possui nenhuma depedência.
- **Application** — Contém as DTOs, services e as validações. É responsável pelos casos de uso da aplicação, ela atua como um intermediário entre as API e o Domain. 
- **Infrastructure** — Contém as informações do banco de dados, migrations e repositórios. É responsável por implementar o acesso aos dados utilizando o EntityFramework
- **API** — Contém os controllers, middleware e configurações da aplicação. É a camada de apresentação, ela é responsável por receber as requisições HTTP e devolver para quem estiver consumindo a API.

```txt
              API
             /   \
            ↓     ↓
   Application   Infrastructure
            \     /
             ↓   ↓
             Domain
```

## Decisões técnicas

Boa parte das decisões técnicas tomadas se dão pela minha curiosidade e intesse em conhecer novas tecnologias. 

- **Clean Architecture** — Optei por utilizar Clean Architecture devido a sua organização em camadas. Por mais que seja uma artquitetura mais focada em projetos frequentemnte maiores, aproveitei o desafio para colocar em prática esse conceito e aprofundar meu entendimento sobre arquitetura de software.
- **DTOs** - Utilizei DTOs para ter um controle melhor nas entradas e saídas da API. Isso evita expor diretamente as entidades do Domain. E isso facilita as validações, reduz o acoplamento e pensado a longo prazo torna a API mais flexível. É abstração na prática.
- **Validação em duas camadas** — DTOs validam formato dos dados garantindo, obrigatoriedade, tamanho máximo, formato de e-mail, Services validam regras de negócio como CPF único, E-mail já cadastrado e IDs não encontrados.
- **Injeção de Depêndecia** - Usei para garantir o desacoplamento das camadas da aplicação. Deixa o código mais organizado e reutilizável.
- **Repository Pattern** — Utilizei Repositories para centralizar as operações de acesso ao banco de dados e manter os Services focados nas regras de negócio, deixando as responsabilidades da aplicação mais organizadas.
- **Mapeamento Manual** - Optei por utilizar o mapeamento manual entre entidades e DTOs por se tratar de um projeto pequeno. Assim, eu consegui uma transformação de dados exlícitas e de fácil entendimento.
- **Middleware Global de Exceções** - Implementei um middleware para centralizar o tratamento de erros da API, retornando respostas padronizadas e evitando repetição de código.
- **Migrations Automáticas** - Configurei a aplicação para aplicar automaticamente as migrations ao subir a API. Isso simplifica a configuração e reduz a necessidade de executar comandos para criação ou atualização do banco de dados.
- **Swagger** - Utilizei Swagger para documentar e testar o endpoints da API de forma mais rápida.
- **Docker** - Utilizei o Docker Compose para orquestrar os containers da aplicação, automatizando a inicialização do banco de dados e da API em um único comando. Também  foi configurado um healthcheck para garantir que a API seja iniciada apenas após o banco estar disponível.

## Endpoints

### Funcionários

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | /api/funcionarios | Lista todos |
| GET | /api/funcionarios/{id} | Busca por ID |
| POST | /api/funcionarios | Cadastra novo |
| PUT | /api/funcionarios/{id} | Atualiza |
| DELETE | /api/funcionarios/{id} | Remove |

### Departamentos

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | /api/departamentos | Lista todos |
| GET | /api/departamentos/{id} | Busca por ID |
| POST | /api/departamentos | Cadastra novo |
| PUT | /api/departamentos/{id} | Atualiza |
| DELETE | /api/departamentos/{id} | Remove |

## Melhorias Futuras

Embora o projeto atenda os requisitos propostos, algumas melhorias poderiam ser implementadas em versões futuras: 

- **Frontend Web** - O desenvolvimento de um front-end para consumir os endpoints da API e fornecer uma interface gráfica para o gerenciamento de funcionários e departamentos.
- **Teste automatizados** - Adicionar testes unitários para validas as regras de negócio implementadas no Service e testes de integração para verificar o comportamento dos endpoints da API, isso aumenta a confiabilidade na aplicação e facilita futuras manutenções.
- **Autorização e autenticação** - Implementar um controle de acesso baseado em perfis de usuário e implementa autenticação com JWT.
- **Paginação e filtro** - Adicionar paginação, ordenação e filtro nos endpoints para melhorar a escalabilidade das listagens.

## Considerações Finais 

Esse projeto foi desenvolvido com objetivo de atender aos requisitos propostos no desafio técnico.

Além da implementação das funcionalidades solicitadas, o projeto serviu como uma oportunidade para eu conseguir aprofundar meu conhecimento sobre arquitetura em camadas, Entity Framework, Docker, tratamento global de execeções e organizar o projeto usando Clean Architecture. Além de me fazer estudar e conseguir aplicar novas tecnologias como DTOs em um curto período de tempo.

Embora existam melhorias que poderiam ser incorporadas em versões futuras, a aplicação funcional, documentada e preparada para a execucação tanto em ambiente local quanto utilizando Docker.
  
