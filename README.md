**Visão Geral**
O Sistema de processamento de videos  permite os usuários fazer upload de videos e conseguir fazer o download dos mesmos em formato .zip através de uma interface gráfica.

**Requisitos do Sistema**
O sistema deve ser acessível através de um navegador web moderno.
Os usuários devem poder se cadastrar e fazer login na aplicação.
Os usuários devem poder fazer upload de vídeos.
Os usuários devem poder fazer o download dos vídeos .zip.

**Arquitetura e stack**
Para esse serviço utilizamos a divisão em camadas e DDD, separando cada responsabilidade. O projeto consiste nas seguintes camadas: Api, Aplication, Domain, Infra e Worker.

O Sistema de Gerenciamento de Tarefas é construído usando as seguintes tecnologias:
Frontend: HTML, CSS, Razor.
Backend: C#, .Net 8, EF.
Banco de Dados: SQL Server.
Mensageria: RabbitMq.
A aplicação segue uma arquitetura de cliente-servidor, com o frontend se comunicando com o backend através de uma API RESTful. O banco de dados SqlServer é utilizado para armazenar os vídeos .zip em formato base64.

**Como Usar**
Acesse o sistema através do seguinte URL: [url-do-sistema].
Clique em "Registrar" para criar uma nova conta ou faça login se já tiver uma conta.
Na página principal, você verá um input para fazer o upload do vídeo.
Então você poderá consultar a lista de vídeos disponíveis e fazer download.
