"# HABITACAO" 
https://app.screencast.com/vNSp1hhtHulam?conversation=6pB3oV1enclQNCplXVahYR

Nome do Seu Projeto : Sorteio Habitacional

Pré-requisitos
Node.js instalado
Angular CLI instalado
Visual Studio Code (ou outra IDE de sua escolha)
SQL Server instalado
ASP.NET Core SDK 7 instalado
Configuração do Banco de Dados
Crie um banco de dados no SQL Server.

Abra o arquivo appsettings.json na pasta Api e atualize a string de conexão:

json
Copy code
"ConnectionStrings": {
  "DefaultConnection": "Server=seu-servidor;Database=seu-banco-de-dados;Trusted_Connection=True;"
},
No terminal, navegue até a pasta Api e execute as migrações para criar as tabelas:

bash
Copy code
cd Api
dotnet ef database update
Executando a API
No terminal, navegue até a pasta Api:

bash
Copy code
cd Api
Execute o seguinte comando para iniciar a API:

bash
Copy code
dotnet run
A API estará disponível em https://localhost:5001.

Configuração do Frontend Angular
No terminal, navegue até a pasta ClientApp:

bash
Copy code
cd ClientApp
Execute o seguinte comando para instalar as dependências:

bash
Copy code
npm install
Executando o Frontend Angular
No terminal, na pasta ClientApp, execute o seguinte comando para iniciar o aplicativo Angular:

bash
Copy code
ng serve
O aplicativo estará disponível em http://localhost:4200.

Acessando a Aplicação
Abra o navegador e acesse http://localhost:4200 para acessar a aplicação Angular.
