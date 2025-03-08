using System.Numerics;
class Leitor
{
    public string Nome {get; set;}
    public BigInteger Cpf {get; set;}
    public List<Livro> Livros {get; set;}

    public Leitor(string nome, BigInteger cpf)
    {
        Nome = nome;
        Cpf = cpf;
        Livros = new List<Livro>();
    }

    public void AdicionarLivro(Livro livro)
    {
        Livros.Add(livro);
    }

    public void RemoverLivro(Livro livro)
    {
        Livros.Remove(livro);
    }

    public void ExibirLivros()
    {
        Console.WriteLine($"Livros de {Nome}");
        foreach (var livro in Livros)
        {
            Console.WriteLine($"Título: {livro.Titulo}");
            Console.WriteLine($"Escrito por: {livro.Escritor}");
            Console.WriteLine($"Ano de publicação: {livro.Ano}");
            Console.WriteLine($"Gênero: {livro.Genero}");

        }
    }

}