# Cadastro Documento Api

Projeto de cadastro de documentos


# Configuração

Há duas opço~es para configurar o projeto

- 1º opção 

> Baixar a imagem docker com a mesma definição de que está no projeto
```
docker run --name mysql1 -p 3306:3306 -e MYSQL_ROOT_HOST=% -e MYSQL_ROOT_PASSWORD=root -d mysql:latest
```

- 2º opção: 

```
Abrir o arquivo program.cs do e definir a ConnectionString de acordo com as configurações do seu banco mysql local.
```

### Configuração string de conexão padrão

```
server=localhost;database=homedb;user=root;password=root
```

# Collection postman 
`https://www.getpostman.com/collections/a3c1f82377a1a44be9b8`


# rodar o projeto

> 1. Rodar Migrations
> 2. Atualizar o banco
> 3. dotnet run


# Front end

> [link](https://github.com/venilson1/site-cadastro-documento) do repositorio do prjoto frontend da api



