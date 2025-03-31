# Agenda de contatos para intranet

## Requisitos de software

__Problema:__

Diante o crescimento da empresa, está havendo uma certa dificuldade na comunicação interna, pois há mais de 500 funcionários, uns com e-mail, outros com ramais IP e alguns outros com numeros de celular da empresa. Uma pessoa pode ter mais de um meio de contato, dentre esses apresentados.

<br/>

__Estrutura Atual:__

As listas de ramais são atualizadas manualmente em uma planilha, onde um contato deve estar dentro de um setor, que por sua vez, deve estar dentro de uma filial. Os setores podem ter mais de um contato, porem cada contato só pode possuir um setor (quando uma pessoa tem funções em mais de um setor, ela é colocada no setor de maior atuação). não é exibida na lista setores ou filiais sem contatos.

A lista de contatos é controlada de maneira manual, em um arquivo 'xlsx', onde cada contato está contido dentro de um setor, e cada setor, por sua vez, está contido dentro de uma filial. Os setores podem conter diversos contatos e apenas uma filial, enquanto um contato pode conter apenas um setor de origem.

<br/>

__Objetivo:__

Criar uma pagina web para ser usado na intranet da empresa, na qual é possivel ver e pesquisar os contatos desejados.

Somente a equipe responsável poderá incluir, alterar ou excluir os dados, e os visitantes da página poderão apenas visualizar.

É de grande importância permitir que os visitantes da página enviem "notas" de atualização, para a equipe responsável pela própria interface.

<br/>


# Tecnologias utilizadas

## Aplicação
- .NET Core 9.0
- ASP.NET Core
- Entity Framework Core
- SQL Server Express

## Testes
- xUnit
- Moq
- Bogus





