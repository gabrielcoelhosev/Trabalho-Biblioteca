using System.Numerics;
using System.Collections.Generic;

public static class FuncoesBiblioteca
{

    private static Dictionary<string, Leitor> Leitores = new Dictionary<string, Leitor>();
    private static Dictionary<string, Livro> Livros = new Dictionary<string, Livro>();
    public static void CadastrarLeitor()
    
    {
        Console.Clear();
        BigInteger cpf;

        Console.WriteLine("Digite um nome para o leitor: ");
        String? nome = Console.ReadLine();
        Console.WriteLine("=======================");
        Console.WriteLine("Digite um CPF do leitor: ");
        BigInteger.TryParse(Console.ReadLine(), out cpf);
        Console.WriteLine("=======================");
        Console.WriteLine("Digite um nome para armazenar esse leitor no sistema: ");
        string? NomeSitema = Console.ReadLine();
        Console.WriteLine("=======================");
    
        List<Livro> listaLeitor1 = new List<Livro>();

        Leitor  NovoLeitor = new Leitor(nome, cpf);

        Leitores[NomeSitema] = NovoLeitor;

    }

    public static void Listarleitores()
    {
        
        if(Leitores.Count == 0){
            Console.WriteLine("Nenhum leitor cadastrado. ");
            return;
        }

        Console.WriteLine("Leitores Cadastrados");
        foreach (var par in Leitores)
        {
            Console.WriteLine($"Nome no sistema: {par.Key}");
            Console.WriteLine("=====================");
            Console.WriteLine($"Nome:{par.Value.Nome}");
            Console.WriteLine("=====================");
            Console.WriteLine($"CPF{par.Value.Cpf}");
            Console.WriteLine("=====================");
            par.Value.ExibirLivros();
        }
    }


    public static void CadastrarLivro()
    {
        Console.Clear();
        Console.WriteLine("Digite o titulo do livro: ");
        String? Titulo = Console.ReadLine();
        Console.WriteLine("Digite o nome do escritor: ");
        String? Escritor = Console.ReadLine();
        Console.WriteLine("Digite o genero do livro: ");
        String? Genero = Console.ReadLine();
        Console.WriteLine("Digite o ano de publicação do livro: ");
        int Ano = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite um nome para armazenar no sistema:  ");
        String? NomeSistema = Console.ReadLine();

        Livro NovoLivro = new Livro(Titulo, Escritor, Genero, Ano);

        Livros[NomeSistema] = NovoLivro;

    }


    public static void ListarLivros()
    {
        if(Livros.Count == 0)
        {
            
            Console.WriteLine("Nenhum livro cadastrado!");
            return;
        }

        Console.WriteLine("Livros Cadastrados");
        foreach(var lv in Livros)
        {
            Console.WriteLine($"Nome no sistema: {lv.Key}");
            Console.WriteLine("=========================");
            Console.WriteLine($"Título: {lv.Value.Titulo}");
            Console.WriteLine("=========================");
            Console.WriteLine($"Escritor: {lv.Value.Escritor}");
            Console.WriteLine("=========================");
            Console.WriteLine($"Genero: {lv.Value.Genero}");
            Console.WriteLine("=========================");
            Console.WriteLine($" Ano de publicação: {lv.Value.Ano}");
        }
    }

    public static void VincularLivro()
    {
        Console.Clear();
        Console.WriteLine("Digite o nome do leitor no sistema:");
        string? nomeSistemaLeitor = Console.ReadLine().ToUpper();

        if (!Leitores.TryGetValue(nomeSistemaLeitor, out Leitor? leitor))
        {
       
        Console.WriteLine("Leitor não encontrado!");
        return;
        }

        Console.WriteLine("Digite o nome do livro no sistema:");
        string? nomeSistemaLivro = Console.ReadLine();

        if (!Livros.TryGetValue(nomeSistemaLivro, out Livro? livro))
        {
            
            Console.WriteLine("Livro não encontrado!");
            return;
        }

        leitor.AdicionarLivro(livro);
        Console.WriteLine($"Livro '{livro.Titulo}' vinculado ao leitor '{leitor.Nome}' com sucesso!");
    }

    public static void DesvincularLivro()
    {
        Console.Clear();
        Console.WriteLine("Digite o nome do leitor no sistema:");
        string? nomeSistemaLeitor = Console.ReadLine();

        if (!Leitores.TryGetValue(nomeSistemaLeitor, out Leitor? leitor))
        {
        Console.WriteLine("Leitor não encontrado!");
        return;
        }

        Console.WriteLine("Digite o nome do livro no sistema:");
        string? nomeSistemaLivro = Console.ReadLine();

        if (!Livros.TryGetValue(nomeSistemaLivro, out Livro? livro))
        {
            Console.WriteLine("Livro não encontrado!");
            return;
        }

        leitor.RemoverLivro(livro);
        Console.WriteLine($"Livro '{livro.Titulo}' desvinculado do '{leitor.Nome}' com sucesso!");
    }

    public static void DoarLivro()
{
    Console.Clear();
    Console.WriteLine("Digite o nome do leitor doador no sistema:");
    string? nomeSistemaDoador = Console.ReadLine();

    if (!Leitores.TryGetValue(nomeSistemaDoador, out Leitor? leitorDoador))
    {
        Console.WriteLine("Leitor doador não encontrado!");
        return;
    }

    Console.WriteLine("Digite o nome do leitor receptor no sistema:");
    string? nomeSistemaReceptor = Console.ReadLine();

    if (!Leitores.TryGetValue(nomeSistemaReceptor, out Leitor? leitorReceptor))
    {
        Console.WriteLine("Leitor receptor não encontrado!");
        return;
    }

    Console.WriteLine("Digite o nome do livro no sistema que será doado:");
    string? nomeSistemaLivro = Console.ReadLine();

    if (!Livros.TryGetValue(nomeSistemaLivro, out Livro? livro))
    {
        Console.WriteLine("Livro não encontrado!");
        return;
    }

    if (!leitorDoador.TemLivro(livro))
    {
    
        Console.WriteLine($"O livro '{livro.Titulo}' não está com o leitor '{leitorDoador.Nome}'!");
        return;
    }

    leitorDoador.RemoverLivro(livro);
    leitorReceptor.AdicionarLivro(livro);
    Console.WriteLine($"Livro '{livro.Titulo}' doado de '{leitorDoador.Nome}' para '{leitorReceptor.Nome}' com sucesso!");
}
}