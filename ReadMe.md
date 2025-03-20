# Agenda de contatos para intranet

## Requisitos de software

__Problema:__

Diante o crescimento da empresa, está havendo uma certa dificuldade na comunicação interna, pois há mais de 500 funcionários, uns com e-mail, outros com ramais IP e alguns outros com numeros de celular da empresa. Uma pessoa pode ter mais de um meio de contato, dentre esses apresentados.

Os ramais são gerenciados de maneira manual, na qual há diversas inconcistencias, devido a constantes atualualizações e a falta de tempo que a equipe responsável possui.

E-mails e numeros de celular da empresa não são gerenciados em nenhuma agenda, pois é inviável tal ação com a estrutura atual. Isso gera um envio incorreto dos e-mails e falta de comunicação via celulares da empresa.

<br/>

__Estrutura Atual:__

As listas de ramais são atualizadas manualmente em uma planilha, onde um contato deve estar dentro de um setor, que por sua vez, deve estar dentro de uma filial. Os setores podem ter mais de um contato, porem cada contato só pode possuir um setor (quando uma pessoa tem funções em mais de um setor, ela é colocada no setor de maior atuação). não é exibida na lista setores ou filiais sem contatos.

Os celulares e emails não tem uma regra pré-definida, pois não são gerenciados.

Não há uma base de dados que é possível consutar nenhum dos meios de contatos, então deverá ser criado uma base para a inserção dos mesmos.


<br/>

__Objetivo:__

Criar uma pagina web para ser usado na intranet da empresa, na qual é possivel ver e pesquisar os contatos desejados. A pesquisa poderá ser feita por nome ou setor.

Somente a equipe responsável poderá incluir, alterar ou excluir os dados, e os visitantes da página poderão apenas visualizar.

É de grande importância permitir que os visitantes da página enviem "notas" de atualização, para a equipe responsável pela própria interface.

<br/>

__Solução:__

Criar uma aplicação MVC e uma base de dados para atender os requisitos solicitados.

<br/>

# Tecnologias utilizadas

## Aplicação
- .NET Core 9.0
- ASP.NET Core
- Entity Framework Core
- SQL Sercer Express

## Testes
- xUnit
- Moq
- Bogus

Foi escolhido utilizar o templte _MVC_, da aspnet.
Essa aplicação não depende de uma base de dados específica, pois será utilizado um ORM para gerenciar a criação e controle das entidades.




