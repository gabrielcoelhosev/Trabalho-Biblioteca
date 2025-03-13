class Leitor
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public List<Livro> Livros { get; set; }

    public Leitor(string nome, string cpf)
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
        if (Livros.Count == 0)
        {
            Console.WriteLine("Nenhum livro associado a este leitor.");
            return;
        }

        Console.WriteLine($"Livros de {Nome}:");
        foreach (var livro in Livros)
        {
            livro.ExibirDados();
        }
    }

    //leandro jader e gabriel coelho severino
}
