class Livro
{
    public string Titulo { get; set; }
    public string Escritor { get; set; }
    public string Genero { get; set; }
    public int Ano { get; set; }

    public Livro(string titulo, string escritor, string genero, int ano)
    {
        Titulo = titulo;
        Escritor = escritor;
        Genero = genero;
        Ano = ano;
    }

    public void ExibirDados()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Título: {Titulo}, Autor: {Escritor}, Gênero: {Genero}, Ano: {Ano}");
        Console.ResetColor();
    }
}
