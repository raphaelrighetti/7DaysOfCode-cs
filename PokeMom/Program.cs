using PokeMom.Menus;
using PokeMom.Utils;

var tempoSleep = 2000;
var menus = new Menu[]
{
    new MenuListagemPokemon("Menu Listagem Pokemon")
};

ExibirTelaInicial();
ExibirOpcoes();

void ExibirTelaInicial()
{
    Console.WriteLine("Bem vindo ao PokeMom!\n");
    Console.WriteLine("Já imaginou ter um Pokemon como filho? Nem eu, mas aqui você pode!");
    Console.WriteLine("Cuide do seu Pokemon como você cuida do seu pet e seja feliz...\n");
    Console.WriteLine("Aperte qualquer tecla para continuar...");

    Console.ReadKey();
}

void ExibirOpcoes()
{
    Console.Clear();

    Console.WriteLine("Escolha uma opção:\n" +
    "1 - Listar os Pokemon disponíveis\n" +
    "2 - Sair");

    var opcao = Console.ReadLine();

    if (!PokeMomUtil.OpcaoValida(opcao))
    {
        Console.WriteLine("Digite uma opção válida...");

        Thread.Sleep(tempoSleep);
        ExibirOpcoes();
        return;
    }

    var opcaoNumero = int.Parse(opcao!) - 1;
    if (opcaoNumero > menus.Length) return;

    menus[opcaoNumero].Prompt();
    ExibirOpcoes();
}
