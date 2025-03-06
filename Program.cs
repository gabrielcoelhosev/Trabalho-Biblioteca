using System;
using System.Collections.Generic;
using System.Numerics;

public class Livro
{
    public string Titulo { get; set; }
    public string SubTitulo { get; set; }
    public string Escritor { get; set; }
    public string Editora { get; set; }
    public string Genero { get; set; }
    public int AnoPublicacao { get; set; }
    public string TipoDaCapa { get; set; }
    public int NumeroDePaginas { get; set; }

    public Livro(string titulo, string subtitulo, string escritor, string editora, string genero, int anoPublicacao, string tipoDaCapa, int numeroDePaginas) =>
        (Titulo, SubTitulo, Escritor, Editora, Genero, AnoPublicacao, TipoDaCapa, NumeroDePaginas) = 
        (titulo, subtitulo, escritor, editora, genero, anoPublicacao, tipoDaCapa, numeroDePaginas);

    public override string ToString() => $"{Titulo} - {SubTitulo} ({Escritor}, {AnoPublicacao})";
}

public class Leitor
{
    public string Nome { get; set; }
    public BigInteger Cpf { get; set; }
    public string Sexo { get; set; }
    public BigInteger Fone { get; set; }

    public List<Livro> LivrosEmprestados { get; set; } = new List<Livro>();

    public Leitor(string nome, BigInteger cpf, string sexo, BigInteger fone) =>
        (Nome, Cpf, Sexo, Fone) = (nome, cpf, sexo, fone);

    public override string ToString() => $"{Nome} (CPF: {Cpf})";
}

public class Biblioteca
{
    private readonly List<Leitor> leitores = new List<Leitor>();
    private readonly List<Livro> livrosDisponiveis = new List<Livro>();
    private readonly Dictionary<string, Action> menu;

    public Biblioteca()
    {
        menu = new Dictionary<string, Action>
        {
            {"1", CadastrarLeitor}, {"2", ListarLeitores}, {"3", AdicionarLivro}, {"4", RemoverLivro}, {"5", PesquisarLivro}, {"6", DoarLivro}
        };
    }

    public void Executar()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Biblioteca ===");
            Console.WriteLine("1-Cadastrar Leitor | 2-Listar Leitores | 3-Adicionar Livro | 4-Remover Livro | 5-Pesquisar Livro | 6-Doar Livro | 0-Sair");
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();
            if (opcao == "0") return;
            if (!menu.TryGetValue(opcao, out var acao)) Pausar("Opção inválida!");
            else acao();
        }
    }

    private void CadastrarLeitor()
    {
        var leitor = CriarLeitor();
        if (leitor == null) return;

        if (leitores.Exists(l => l.Cpf == leitor.Cpf))
        {
            Pausar("CPF já cadastrado!");
            return;
        }
        leitores.Add(leitor);
        Pausar("Leitor cadastrado!");
    }

    private void ListarLeitores()
    {
        if (leitores.Count == 0)
        {
            Pausar("Nenhum leitor cadastrado!");
            return;
        }

        foreach (var leitor in leitores)
        {
            Console.WriteLine(leitor);
            Console.Write("Livros: ");
            if (leitor.LivrosEmprestados.Count == 0)
                Console.WriteLine("Nenhum livro.");
            else
                Console.WriteLine(string.Join(", ", leitor.LivrosEmprestados));
        }
        Pausar();
    }

    private void AdicionarLivro()
    {
        var leitor = BuscarLeitor();
        if (leitor == null) return;

        leitor.LivrosEmprestados.Add(CriarLivro());
        Pausar("Livro adicionado!");
    }

    private void RemoverLivro()
    {
        var leitor = BuscarLeitor();
        if (leitor == null) return;

        if (leitor.LivrosEmprestados.Count == 0)
        {
            Pausar("Nenhum livro para remover!");
            return;
        }

        int indice = SelecionarLivro(leitor);
        if (indice == -1) return;

        leitor.LivrosEmprestados.RemoveAt(indice);
        Pausar("Livro removido!");
    }

    private void PesquisarLivro()
    {
        string titulo = Prompt("Título: ");
        bool encontrado = false;

        foreach (var leitor in leitores)
        {
            foreach (var livro in leitor.LivrosEmprestados)
            {
                if (livro.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{leitor}: {livro}");
                    encontrado = true;
                }
            }
        }
        if (!encontrado) Console.WriteLine("Livro não encontrado!");
        Pausar();
    }

    private void DoarLivro()
    {
        var livro = CriarLivro();
        livrosDisponiveis.Add(livro);
        Pausar("Livro doado com sucesso!");
    }

    private Leitor CriarLeitor()
    {
        string nome = Prompt("Nome: ");

        if (!BigInteger.TryParse(Prompt("CPF: "), out BigInteger cpf))
        {
            Pausar("CPF inválido!");
            return null;
        }

        string sexo = Prompt("Sexo: ");

        if (!BigInteger.TryParse(Prompt("Fone: "), out BigInteger fone))
        {
            Pausar("Número de telefone inválido!");
            return null;
        }

        return new Leitor(nome, cpf, sexo, fone);
    }

    private Livro CriarLivro()
    {
        return new Livro(
            Prompt("Título: "),
            Prompt("Subtítulo: "),
            Prompt("Escritor: "),
            Prompt("Editora: "),
            Prompt("Gênero: "),
            int.Parse(Prompt("Ano: ")),
            Prompt("Tipo da Capa: "),
            int.Parse(Prompt("Páginas: "))
        );
    }

    private Leitor BuscarLeitor()
    {
        if (!BigInteger.TryParse(Prompt("CPF: "), out BigInteger cpf))
        {
            Pausar("CPF inválido!");
            return null;
        }

        Leitor leitor = leitores.Find(l => l.Cpf == cpf);
        if (leitor == null) Pausar("Leitor não encontrado!");

        return leitor;
    }

    private int SelecionarLivro(Leitor leitor)
    {
        for (int i = 0; i < leitor.LivrosEmprestados.Count; i++)
            Console.WriteLine($"{i + 1}. {leitor.LivrosEmprestados[i]}");

        if (!int.TryParse(Prompt("Número do livro: "), out int indice) || indice < 1 || indice > leitor.LivrosEmprestados.Count)
        {
            Pausar("Opção inválida!");
            return -1;
        }

        return indice - 1;
    }

    private string Prompt(string msg)
    {
        Console.Write(msg);
        return Console.ReadLine();
    }

    private void Pausar(string msg = "")
    {
        Console.WriteLine($"{msg}\nPressione Enter...");
        Console.ReadLine();
    }
}

public class Program
{
    public static void Main() => new Biblioteca().Executar();
}