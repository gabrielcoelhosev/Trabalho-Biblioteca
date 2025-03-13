using System;
using System.Linq;
using System.Collections.Generic;

class Biblioteca
{
    private static Dictionary<string, Leitor> leitores = new Dictionary<string, Leitor>();
    private static List<Livro> livros = new List<Livro>();

    public static void CadastrarLeitor()
    {
        Console.WriteLine("Digite o nome do leitor:");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite o CPF do leitor:");
        string cpf = Console.ReadLine();

        if (leitores.ContainsKey(cpf))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Leitor com esse CPF já cadastrado.");
            Console.ResetColor();
            return;
        }

        Leitor novoLeitor = new Leitor(nome, cpf);
        leitores[cpf] = novoLeitor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Leitor cadastrado com sucesso.");
        Console.ResetColor();
    }

    public static void ListarLeitores()
    {
        if (leitores.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nenhum leitor cadastrado.");
            Console.ResetColor();
            return;
        }

        foreach (var leitor in leitores.Values)
        {
            Console.WriteLine("==================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Leitor: {leitor.Nome} (CPF: {leitor.Cpf})");
            leitor.ExibirLivros();
            Console.ResetColor();
        }
    }

    public static void EditarLeitor()
    {
        Console.WriteLine("Digite o CPF do leitor para editar:");
        string cpf = Console.ReadLine();

        if (!leitores.ContainsKey(cpf))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Leitor não encontrado.");
            Console.ResetColor();
            return;
        }

        Leitor leitor = leitores[cpf];
        Console.WriteLine("Digite o novo nome do leitor:");
        leitor.Nome = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Leitor atualizado com sucesso.");
        Console.ResetColor();
    }

    public static void ExcluirLeitor()
    {
        Console.WriteLine("Digite o CPF do leitor para excluir:");
        string cpf = Console.ReadLine();

        if (!leitores.ContainsKey(cpf))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Leitor não encontrado.");
            Console.ResetColor();
            return;
        }

        leitores.Remove(cpf);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Leitor excluído com sucesso.");
        Console.ResetColor();
    }

    public static void CadastrarLivro()
    {
        Console.WriteLine("Digite o título do livro:");
        string titulo = Console.ReadLine();
        Console.WriteLine("Digite o autor do livro:");
        string autor = Console.ReadLine();
        Console.WriteLine("Digite o gênero do livro:");
        string genero = Console.ReadLine();
        Console.WriteLine("Digite o ano de publicação do livro:");
        int ano = int.Parse(Console.ReadLine());

        Livro novoLivro = new Livro(titulo, autor, genero, ano);
        livros.Add(novoLivro);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Livro cadastrado com sucesso.");
        Console.ResetColor();
    }

    public static void EditarLivro()
    {
        Console.WriteLine("Digite o título do livro para editar:");
        string titulo = Console.ReadLine();

        Livro livro = livros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (livro == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Livro não encontrado.");
            Console.ResetColor();
            return;
        }

        Console.WriteLine("Digite o novo título do livro:");
        livro.Titulo = Console.ReadLine();
        Console.WriteLine("Digite o novo autor do livro:");
        livro.Escritor = Console.ReadLine();
        Console.WriteLine("Digite o novo gênero do livro:");
        livro.Genero = Console.ReadLine();
        Console.WriteLine("Digite o novo ano de publicação do livro:");
        livro.Ano = int.Parse(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Livro atualizado com sucesso.");
        Console.ResetColor();
    }

    public static void RemoverLivro()
    {
        Console.WriteLine("Digite o título do livro para remover:");
        string titulo = Console.ReadLine();

        Livro livro = livros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (livro == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Livro não encontrado.");
            Console.ResetColor();
            return;
        }

        livros.Remove(livro);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Livro removido com sucesso.");
        Console.ResetColor();
    }

    public static void DoarLivro()
    {
        Console.WriteLine("Digite o CPF do leitor doador:");
        string cpfDoador = Console.ReadLine();

        if (!leitores.ContainsKey(cpfDoador))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Leitor doador não encontrado.");
            Console.ResetColor();
            return;
        }

        Leitor doador = leitores[cpfDoador];

        Console.WriteLine("Digite o CPF do leitor receptor:");
        string cpfReceptor = Console.ReadLine();

        if (!leitores.ContainsKey(cpfReceptor))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Leitor receptor não encontrado.");
            Console.ResetColor();
            return;
        }

        Leitor receptor = leitores[cpfReceptor];

        Console.WriteLine("Digite o título do livro a doar:");
        string titulo = Console.ReadLine();

        Livro livro = doador.Livros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (livro == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Livro não encontrado.");
            Console.ResetColor();
            return;
        }

        doador.RemoverLivro(livro);
        receptor.AdicionarLivro(livro);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Livro '{livro.Titulo}' doado de {doador.Nome} para {receptor.Nome}.");
        Console.ResetColor();
    }

    public static void ListarLivrosDeUmLeitor()
    {
        Console.WriteLine("Digite o CPF do leitor para listar seus livros:");
        string cpf = Console.ReadLine();

        if (!leitores.ContainsKey(cpf))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Leitor não encontrado.");
            Console.ResetColor();
            return;
        }

        leitores[cpf].ExibirLivros();
    }

    public static void BuscarLivroPorTitulo()
    {
        Console.WriteLine("Digite o título do livro para buscar:");
        string titulo = Console.ReadLine();

        Livro livro = livros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (livro == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Livro não encontrado.");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Livro encontrado:");
        livro.ExibirDados();
        Console.ResetColor();
    }

    public static void ListarLivrosCadastrados()
    {
        if (livros.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nenhum livro cadastrado.");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Livros cadastrados:");
        foreach (var livro in livros)
        {
            livro.ExibirDados();
        }
        Console.ResetColor();
    }

    public static void AtribuirLivroALeitor()
    {
        Console.WriteLine("Digite o CPF do leitor:");
        string cpf = Console.ReadLine();

        if (!leitores.ContainsKey(cpf))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Leitor não encontrado.");
            Console.ResetColor();
            return;
        }

        Leitor leitor = leitores[cpf];

        Console.WriteLine("Digite o título do livro para atribuir:");
        string titulo = Console.ReadLine();

        Livro livro = livros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (livro == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Livro não encontrado.");
            Console.ResetColor();
            return;
        }

        if (leitor.Livros.Contains(livro))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Este livro já está atribuído a este leitor.");
            Console.ResetColor();
            return;
        }

        leitor.AdicionarLivro(livro);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Livro '{livro.Titulo}' atribuído ao leitor {leitor.Nome} com sucesso.");
        Console.ResetColor();
    }                                      //leandro jader e gabriel coelho severino
}
