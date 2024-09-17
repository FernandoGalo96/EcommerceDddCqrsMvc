E-commerce Completo com DDD, CQRS e Design Patterns
Este projeto consiste no desenvolvimento de uma aplicação de e-commerce utilizando os princípios de Domain-Driven Design (DDD), Command Query Responsibility Segregation (CQRS) e Design Patterns, com uma arquitetura voltada para alta escalabilidade e manutenibilidade.

Principais Características:
Modelagem Tática com DDD: Utilização de entidades, agregados, repositórios e serviços de domínio para organizar a lógica de negócios de maneira clara e extensível.

CQRS: Separação entre comandos (escrita) e consultas (leitura) para otimizar o desempenho e a organização do código.

Biblioteca de Classes: Implementação modular com bibliotecas de classes, facilitando a reutilização e a separação de responsabilidades.

Patterns: Aplicação de padrões de design como Factory, Repository e Strategy, proporcionando flexibilidade e facilidade de manutenção.

Event-Driven: Uso de eventos para comunicação entre diferentes partes do sistema, garantindo baixa acoplamento e reatividade.

Tecnologias Utilizadas:

ASP.NET Core MVC para o frontend, com interface simples e intuitiva.
Entity Framework Core para o mapeamento objeto-relacional (ORM) e gerenciamento do banco de dados SQL Server.
Identity e JWT Tokens para autenticação e segurança dos usuários.

Funcionalidades Implementadas:

Gerenciamento de produtos, vendas, cadastros de usuários e fluxo completo de pagamento.
Integração com métodos de pagamento e geração de notas fiscais.
Suporte a múltiplos usuários e gestão de pedidos com histórico.
Estrutura de Pastas:
Domain: Camada de domínio contendo as regras de negócio e lógica principal.
Application: Camada de aplicação responsável pelos serviços e CQRS.
Infrastructure: Integrações com banco de dados, repositórios e serviços externos.
Presentation: Interface de usuário com MVC e APIs RESTful.
Essa descrição mostra tanto a arquitetura quanto os detalhes técnicos do projeto, destacando os aspectos principais de DDD, CQRS e Design Patterns.






