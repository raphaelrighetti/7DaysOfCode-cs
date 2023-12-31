﻿using PokeMom.Modelos;
using PokeMom.Utils;
using PokeMom.Views;

namespace PokeMom.Models;

internal class Pokemon
{
    private string nome;

    private readonly int fomeMax = new Random().Next(10, 21);
    private readonly int humorMax = new Random().Next(10, 21);
    private readonly int sonoMax = new Random().Next(10, 21);

    private bool vivo = true;

    private int tempoAcumulado = 0;
    private readonly int intervaloMax = 30;

    private DateTime ultimaAtualizacaoStats = DateTime.Now;

    public Pokemon()
    {
        Fome = fomeMax;
        Humor = humorMax;
        Sono = sonoMax;
    }

    public Pokemon(string nome, int altura, int peso, List<Habilidade> habilidades, Usuario dono)
    {
        this.nome = nome;
        Altura = altura;
        Peso = peso;
        Habilidades = habilidades;
        Dono = dono;
    }

    public string Nome
    {
        get
        {
            return PokeMomUtil.Capitalize(nome);
        }
        set
        {
            nome = value;
        }
    }
    public int Altura { get; set; }
    public int Peso { get; set; }
    public List<Habilidade> Habilidades { get; set; }
    public Usuario Dono { get; set; }

    public int Fome { get; private set; }
    public int Humor { get; private set; }
    public int Sono { get; private set; }

    public void Alimentar()
    {
        if (Fome < fomeMax) Fome++;
        Sono--;

        ChecarMorte();
    }

    public void Brincar()
    {
        if (Humor < humorMax) Humor++;
        Sono--;

        ChecarMorte();
    }

    public void ColocarParaDormir()
    {
        Sono = sonoMax;
        Fome--;

        ChecarMorte();
    }

    public void AtualizarStats()
    {
        if (!vivo) return;

        int valorReducaoStats = 0;

        var agora = DateTime.Now;
        var intervalo = agora - ultimaAtualizacaoStats;
        int minutosPassados = (int)intervalo.TotalSeconds;

        tempoAcumulado += minutosPassados;
        if (tempoAcumulado > intervaloMax)
        {
            valorReducaoStats = tempoAcumulado / intervaloMax;
            tempoAcumulado = 0;
        }

        ReduzirStats(valorReducaoStats);
        ultimaAtualizacaoStats = DateTime.Now;
    }

    private void ReduzirStats(int valor)
    {
        Fome -= valor;
        Humor -= valor;
        Sono -= valor;

        ChecarMorte();
    }

    private void ChecarMorte()
    {
        if (Fome <= 0 || Humor <= 0 || Sono <= 0)
        {
            vivo = false;

            new MenuMorte("Menu Morte", Dono).Prompt();
        }
    }

    public override string ToString()
    {
        return $"Nome: {Nome}\n" +
            $"Altura: {Altura}\n" +
            $"Peso: {Peso}\n" +
            $"Primeira habilidade: {Habilidades![0].Nome}\n\n" +
            $"Fome: {Fome}, \n" +
            $"Humor: {Humor}, \n" +
            $"Sono: {Sono}";
    }
}
