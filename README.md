# PokeMom

***Você já se imaginou sendo uma mãe de um Pokémon? Nem eu, mas aqui você pode!***

PokeMom é uma aplicação de console que funciona como um jogo Tamagochi, mas que utiliza a API do Pokémon para ter acesso aos mascotes disponíveis.

*Este é um projeto desenvolvido ao longo do desafio "7DaysOfCode - C#" da Alura.*

## Progresso no desafio

### Dia 1

O desafio desse dia consistia em fazer a primeira requisição à API do Pokémon utilizando a biblioteca "RestSharp" (ou qualquer outra, mas a sugerida foi essa) e mostrar o retorno da requisição no console.

No entanto, resolvi fazer um menu interativo onde o usuário pode escolher entre as opções disponíveis da aplicação, bem do jeito que uma aplicação de console padrão funciona mesmo. Implementei esse menu de modo que fique mais fácil de implementar novos menus no futuro e o arquivo "Program.cs" não fique tão longo. Fiz isso utilizando uma classe "Menu" da qual todos os outros menus irão herdar e sobrescrever o método "Prompt()", que é o método inicial de todo menu na aplicação.

Também fiz uma lógica que permite o usuário navegar entre as páginas contendo os Pokémon que a API retorna, o que ficou bem legal.

Também vale a pena dizer que para conseguir fazer o que fiz, tive que transformar o JSON retornado pela API em objetos C#, um que representa a lista de Pokémon retornada e outro que representa um Pokémon em si.

### Dia 2

O desafio desse dia consistia em desserializar a resposta da API para um objeto que representasse um Pokémon contendo mais informações do que apenas o nome e a URL do recurso específico daquele Pokémon.

Para isso, precisei fazer uma lógica no menu de listagem dos Pokémon que faz uma requisição na URL específica para cada Pokémon presente na lista, pois não achei um jeito melhor de conseguir informações adicionais no endpoint de listagem dos Pokémon. Isso deixou a aplicação muiiiito mais lenta, mas foi o que eu consegui fazer no tempo que eu tinha. Acredito que tenha uma solução melhor.

De resto, foi só isso mesmo, acabei queimando a largada fazendo mais coisas do que foram pedidas no desafio do primeiro dia.

### Dia 3

O desafio desse dia consistia em construir menus interativos com as seguintes funcionalidades:

1. Mensagem de boas vindas personalizada com o nome do usuário recebido por input

2. Menu principal de opções com as seguintes opções:

	1. Adotar um Pokémon
		
  		Esse é o menu que lista a página de Pokémon disponíveis para a adoção e dá a possibilidade de navegar entre as páginas disponíveis, visualizar mais informações sobre um Pokémon específico e realizar a adoção de um Pokémon escolhido pelo usuário
		
	2. Listar os Pokémon adotados
	
	3. Sair
	
Foi um desafio bem legal e que deixou a aplicação bem mais interessante de ser utilizada, além de mais performática por eu ter tirado a gambiarra que eu fiz para fazer um monte de requisições para cada Pokémon listado na página de Pokémon disponíveis.

Além disso, pude fazer uma espécie de injeção de dependências injetando o usuário para cada menu do sistema, assim fazendo com que as informações de Pokémon adotados estejam sempre atualizadas entre os menus.

### Dia 4

O desafio desse dia consistia em melhorar a arquitetura do projeto aplicando um padrão MVC, separando os menus na pasta "Views", criando controladores na pasta "Controllers", deixando os modelos da aplicação na pasta "Models" e fazendo com que esses diferentes componentes se comuniquem para separar a responsabilidade entre eles.

Entretanto, eu acho que criar controladores e fazer com que eles mostrem as Views, que por sua vez terão que chamar outros controladores que irão mostrar outras Views, apenas deixaria o projeto mais complexo e pior de ser modificado. Creio que tem horas certas para utilizar esse padrão, como no caso do desenvolvimento de aplicações web, onde os controladores estarão escutando aos endpoints do sistema e por aí vai, mas pode ser que eu esteja errado, não tenho experiência em fazer aplicações utilizando o padrão MVC, apenas APIs REST.

O maior problema pra mim em aplicar essa arquitetura é que um controlador precisa de uma View para ser chamado, o que faz ou com que o controlador tenha parte da responsabilidade de uma View, ou com que as Views tenham que ter uma complexidade maior para conseguir transitar os inputs do usuário entre outros controllers e etc. Não é como se essa fosse uma aplicação que necessita de um formato específico pra transitar um JSON para fazer alguma ação de CRUD ou coisa do tipo, tudo o que ela faz que precisa de input do usuário até agora é muito simples, mas enfim.

Fiz algumas mudanças no meu código, adicionando uma nova classe de serviço que é responsável por fazer as requisições à API do Pokémon isolando esse acesso aos recursos e deixando mais fácil de fazer uma futura modificação nisso e organizando melhor o restante das classes que eu já tenho, mas pode ser que eu mude esse esquema que eu fiz dependendo do próximo desafio que eu for resolver.
