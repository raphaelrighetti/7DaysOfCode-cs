# PokeMom

***Você já se imaginou sendo uma mãe de um Pokemon? Nem eu, mas aqui você pode!***

PokeMom é uma aplicação de console que funciona como um jogo Tamagochi, mas que utiliza a API do Pokemon para ter acesso aos mascotes disponíveis.

*Este é um projeto desenvolvido ao longo do desafio "7DaysOfCode - C#" da Alura.*

## Progresso no desafio

### Dia 1

O desafio desse dia consistia em fazer a primeira requisição à API do Pokemon utilizando a biblioteca "RestSharp" (ou qualquer outra, mas a sugerida foi essa) e mostrar o retorno da requisição no console.

No entanto, resolvi fazer um menu interativo onde o usuário pode escolher entre as opções disponíveis da aplicação, bem do jeito que uma aplicação de console padrão funciona mesmo. Implementei esse menu de modo que fique mais fácil de implementar novos menus no futuro e o arquivo "Program.cs" não fique tão longo. Fiz isso utilizando uma classe "Menu" da qual todos os outros menus irão herdar e sobrescrever o método "Prompt()", que é o método inicial de todo menu na aplicação.

Também fiz uma lógica que permite o usuário navegar entre as páginas contendo os Pokemon que a API retorna, o que ficou bem legal.

Também vale a pena dizer que para conseguir fazer o que fiz, tive que transformar o JSON retornado pela API em objetos C#, um que representa a lista de Pokemon retornada e outro que representa um Pokemon em si.
