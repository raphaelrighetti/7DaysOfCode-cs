namespace PokeMom.Utils;

internal static class PokeMomUtil
{
    public static string Capitalize(string str)
    {
        if (str.Length == 0) return str;
        if (str.Length == 1) return str.ToUpper();

        var palavras = str.Split(' ');

        if (palavras.Length == 1)
        {
            return char.ToUpper(str[0]) + str[1..];
        } 
        else
        {
            for ( int i = 0; i < palavras.Length; i++ )
            {
                palavras[i] = char.ToUpper(palavras[i][0]) + palavras[i][1..];
            }

            return string.Join(" ", palavras).Trim();
        }
    }

    public static bool OpcaoEhValida(string? opcao)
    {
        if (opcao == null) return false;
        if (opcao.Equals("")) return false;

        return true;
    }

    public static bool OpcaoEhNumeroPositivo(string opcao)
    {
        try
        {
            var numeroOpcao = int.Parse(opcao);

            if (numeroOpcao < 0) return false;
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }
}
