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
