# TesteCerti
## Desafio técnico de programação - Fundação Certi
Este desafio consiste em desenvolver um servidor HTTP, que por método GET receba um número de -99999 a 99999 e retorne o mesmo número por extenso.

A aplicação foi desenvolvida em .NET e o código principal da aplicação se encontra em:  TesteCerti/src/TesteCerti.API/Controllers/TradutorController.cs

## Rodando a aplicação
### Verificar as suas instalações
Para rodar a aplicação você precisa ter:

git

.Net sdk 5.0.102 (especificamente)

node 14.17.6 ou maior

npm 6.14.15 ou maior

### Clonar o repositório
No diretório de sua escolha digite o comando:

```shell
git clone https://github.com/lucaslopes2000/TesteCerti.git
```

### Restaurar os pacotes na API
Entre na pasta src:

```shell
cd TesteCerti/src
```

E digite o comando para restaurar as dependências:

```shell
dotnet restore TesteCerti.API
```

### Iniciando a aplicação
Entre na pasta principal do projeto:

```shell
cd TesteCerti/src/TesteCerti.API
```

E rode o comando para dar o build:

```shell
dotnet run
```

Será exibido no terminal o endereço HTTP do servidor. Basta adicioná-lo em seu browser juntamente com o número para vê-lo funcionar.
Exemplo:

```
http://localhost:5000/-12500
```

Também é possivel rodar a aplicação utilizando o Swagger, uma interface criada pelo .NET.
Para isso basta digitar o comando abaixo e o seu navegador abre automaticamente uma janela com a aplicação rodando com o Swagger.

```shell
dotnet watch run
```
