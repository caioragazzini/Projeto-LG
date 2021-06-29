# Projeto-LG
Sistema para o grupo Lorem Ipsum Inc, gerencia os cadastros de projetos, seu tempo de duração e realiza uma simulação do cálculo de retorno do investimento.

## Descrição do Projeto
<p align="left">
	Sistema projetado:
	<p>- BackEnd: WebApi construída em .NET Core, Entity Framework Core Dapper Bancos relacionais MYSQL, Entidades criadas utilizando Code First, seguindo os padrões REST na construção das rotas e retornos e documentação utilizando Swagger)</p>
	<p>-FrontEnd: construida em Asp.NETWeb Application .Net Framework 4.7.2</p>
	
### Features
Back End
- [x] ProjetosControllers
- [x] ParticipanteControllers
- [x] ParticipanteProjetosControllers

Front End
- [x] Cadastro de projetos e participantes
- [x] Edição de projetos e participantes
- [x] Exclusão de projetos e participantes
- [x] Detalhes do projeto
- [x] Simulação de projetos


### Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
Visual Studio 2019
MySql 
Além disto é bom ter um editor para trabalhar com o código como [VSCode](https://code.visualstudio.com/)

### 🎲 Rodando o Back End (servidor)

```bash
# Clone este repositório
$ git clone <https://github.com/caioragazzini/Projeto-LG.git>

# Acesse a pasta do projeto no terminal/cmd
$ cd nlw1

# Vá para a pasta server
$ cd server

# Instale as dependências
$ npm install

# Execute a aplicação em modo de desenvolvimento
$ npm run dev:server

# O servidor do BackEnd tem que estar configurado o Localhost - acesse <https://localhost:44394/>
# O BackEnd pode ser testado através do Swagger acessando https://localhost:44394/swagger/index.html
# O FrontEnd não precisa de nenhuma configuração inicial
```

### 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

- [Microsoft Visual Studio](https://expo.io/)
- .Net Framework 4.7.2
- .NET Core
- Entity Framework Core Dapper Bancos relacionais MySQL 
- Swagger


#Autor
Caio Ragazzini
