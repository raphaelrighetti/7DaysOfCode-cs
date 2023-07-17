using PokeMom.Menus;
using PokeMom.Modelos;
using PokeMom.Utils;

namespace PokeMom.Views;

internal class MenuInicial : Menu
{
    private Menu[]? menus;

    public MenuInicial(string titulo) : base(titulo, null)
    {
    }

    public override void Prompt()
    {
        base.Prompt();

        ExibirTelaInicial();
        ExibirOpcoes();
    }

    void ExibirTelaInicial()
    {
        Console.WriteLine("Digite o seu nome...");

        var nome = Console.ReadLine();
        if (nome == null || nome.Equals(""))
        {
            nome = "Fulano";
        }

        Usuario = new Usuario(PokeMomUtil.Capitalize(nome));

        Console.Clear();

        Console.WriteLine($"Bem vindo ao PokeMom, {Usuario.Nome}!\n");
        Console.WriteLine("Já imaginou ter um Pokémon como filho? Nem eu, mas aqui você pode!");
        Console.WriteLine("Cuide do seu Pokémon como você cuida do seu pet e seja feliz..");
        Console.WriteLine("\nAperte qualquer tecla para continuar...");

        Console.ReadKey();
    }

    void ExibirOpcoes()
    {
        Console.Clear();

        Console.WriteLine("Escolha uma opção:\n" +
        "1 - Adotar um Pokémon\n" +
        "2 - Ver como está seu Pokémon\n" +
        "3 - Alimentar seu Pokémon\n" +
        "4 - Brincar com seu Pokémon\n" +
        "5 - Colocar seu Pokémon para dormir\n" +
        "6 - Sair");

        menus = new Menu[]
        {
            new MenuPokemonDisponiveis("Menu Pokémon Disponíveis", Usuario!),
            new MenuPokemonAdotado("Menu Pokémon Adotado", Usuario!),
            new MenuAlimentacao("Menu Alimentação", Usuario!),
            new MenuBrincadeira("Menu Brincadeira", Usuario!),
            new MenuDormir("Menu Dormir", Usuario!)
        };

        var opcao = Console.ReadLine();

        if (!PokeMomUtil.OpcaoEhValida(opcao) || !PokeMomUtil.OpcaoEhNumeroPositivo(opcao!))
        {
            Console.Clear();

            Console.WriteLine("Digite uma opção válida.\n\n");
            Console.WriteLine("Aperte qualquer tecla para continuar...");

            Console.ReadKey();
            ExibirOpcoes();
            return;
        }

        var opcaoNumero = int.Parse(opcao!) - 1;
        if (opcaoNumero >= menus.Length) return;

        menus[opcaoNumero].Prompt();
        ExibirOpcoes();
    }
}
