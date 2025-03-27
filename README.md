# 📝 README - Georeferenciamento API

## 🚀 Visão Geral
API para georreferenciamento, desenvolvida em .NET com Entity Framework Core.

## ⚙️ Configuração do Ambiente

### Pré-requisitos
- [.NET 9.0]
- [Entity Framework Core CLI](https://docs.microsoft.com/ef/core/cli/dotnet)
- Banco de dados configurado (SQL Server)


## 🏗️ Estrutura do Projeto
```
src/
├── Georeferenciamento.Api/      # Camada de API/Web
├── Georeferenciamento.Application/    # Camada de Application
├── Georeferenciamento.Infra/    # Camada de Infraestrutura
├── Georeferenciamento.Domain/     # Camada de Domínio
```

## 🛠️ Comandos Úteis

### Executar Migrations
```bash
dotnet ef database update -s .\src\Georeferenciamento.Api\ -p .\src\Georeferenciamento.Infra\ -v
```

## 🌐 Swagger/OpenAPI
Acesse a documentação da API em:
```
[http://localhost:5289](http://localhost:5289)/swagger
```
