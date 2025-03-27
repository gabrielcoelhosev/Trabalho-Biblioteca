using System;

public class Livro
{
    private string isbn;
    private string titulo;
    private string escritor;
    private string genero;
    private int ano;
    private int numeroDePaginas;

    public string Isbn
    {
        get { return isbn; }
        init { isbn = value.Trim(); }
    }

    public string Titulo
    {
        get { return titulo; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Título não pode ser vazio ou nulo.");
            titulo = value.Trim();
        }
    }

    public string Escritor
    {
        get { return escritor; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Autor não pode ser vazio ou nulo.");
            escritor = value.Trim();
        }
    }

    public string Genero
    {
        get { return genero; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Gênero não pode ser vazio ou nulo.");
            genero = value.Trim();
        }
    }

    public int Ano
    {
        get { return ano; }
        set
        {
            if (value < 1970 || value > DateTime.Now.Year)
                throw new ArgumentException("Ano de publicação inválido. O ano deve estar entre 1970 e o ano atual.");
            ano = value;
        }
    }

    public int NumeroDePaginas
    {
        get { return numeroDePaginas; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Número de páginas não pode ser negativo.");
            numeroDePaginas = value;
        }
    }

    public Livro(int codigo, string titulo, string escritor, string genero, int ano, string isbn, int numeroDePaginas)
    {
        Isbn = isbn;
        Titulo = titulo;
        Escritor = escritor;
        Genero = genero;
        Ano = ano;
        NumeroDePaginas = numeroDePaginas;
    }

    public string ExibirDados()
    {
        return $"ISBN: {Isbn}, Título: {Titulo}, Autor: {Escritor}, Gênero: {Genero}, Ano: {Ano}, Páginas: {NumeroDePaginas}";
    }
}
