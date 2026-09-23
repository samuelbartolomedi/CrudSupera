# CrudSupera

CRUD simples desenvolvido em ASP.NET Core (Razor Pages) para gerenciamento de **Clientes** e suas **Assinaturas**. Projeto criado a partir do scaffold do Visual Studio, usando Entity Framework Core com banco SQLite.

## Tecnologias

- .NET 7
- ASP.NET Core Razor Pages
- Entity Framework Core 7 (SQLite)
- ASP.NET Core Identity (autenticação de usuários)

## Funcionalidades

- CRUD completo de **Clientes** (Nome, Email, CPF)
- CRUD completo de **Assinaturas**, vinculadas a um Cliente (Título, Data início, Data término)
- Validações de campos obrigatórios, tamanho mínimo/máximo e formato de email
- Autenticação de usuários via Identity (login, cadastro, confirmação de conta)

## Estrutura do projeto

```
CrudSupera/
├── Areas/Identity/       # Páginas de autenticação (Identity UI)
├── Data/                 # ApplicationDbContext e Migrations do EF Core
├── Models/               # Entidades Cliente e Assinatura
├── Pages/
│   ├── Clientes/         # CRUD de clientes
│   └── Assinaturas/      # CRUD de assinaturas
└── Program.cs            # Configuração da aplicação
```

## Como executar

### Pré-requisitos

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)

### Passos

```bash
# clone o repositório
git clone https://github.com/samuelbartolomedi/CrudSupera.git
cd CrudSupera

# restaure as dependências
dotnet restore

# aplique as migrations (o banco app.db já vem versionado, mas caso precise recriar)
dotnet ef database update

# rode a aplicação
dotnet run
```

Depois é só acessar `https://localhost:{porta}` no navegador (a porta exata aparece no terminal ao rodar).

## Banco de dados

O projeto usa SQLite com o arquivo `app.db` na raiz. A connection string está em `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "DataSource=app.db;Cache=Shared"
}
```

## Autor

Samuel Bartolomedi — [github.com/samuelbartolomedi](https://github.com/samuelbartolomedi)
