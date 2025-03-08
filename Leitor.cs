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
        if(Livros.Count == 0)
        {
            Console.WriteLine("Nenhum Livro Vinculado");
        }

        Console.WriteLine($"Livros de {Nome}");
        foreach (var livro in Livros)
        {
            Console.WriteLine($"Título: {livro.Titulo}, Escrito por: {livro.Escritor}, Ano de publicação: {livro.Ano}, Gênero: {livro.Genero}");
        }
    }

}