using System;

public class Livro
{
    public int Codigo { get; set; }
    public string Titulo { get; set; }
    public string Escritor { get; set; }
    public string Genero { get; set; }
    public int Ano { get; set; }

    public Livro(int codigo, string titulo, string escritor, string genero, int ano)
    {
        Codigo = codigo;
        Titulo = titulo;
        Escritor = escritor;
        Genero = genero;
        Ano = ano;
    }

    public void ExibirDados()
    {
        Console.WriteLine($"Código: {Codigo}, Título: {Titulo}, Autor: {Escritor}, Gênero: {Genero}, Ano: {Ano}");
    }
}
