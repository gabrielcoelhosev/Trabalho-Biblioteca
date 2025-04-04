using System;
using System.Collections.Generic;

public class Biblioteca
{
    private static Dictionary<string, Leitor> leitores = new Dictionary<string, Leitor>();
    private static Dictionary<int, Livro> livros = new Dictionary<int, Livro>();

    public static bool VerificarCpfExistente(string cpf)
    {
        return leitores.ContainsKey(cpf);
    }

    public static void CadastrarLeitor()
    {
        Console.Write("Nome do Leitor: ");
        string nome = Console.ReadLine();

        Console.Write("CPF do Leitor: ");
        string cpf = Console.ReadLine();

        int idade;
        do
        {
            Console.Write("Idade do Leitor: ");
            idade = int.Parse(Console.ReadLine());
            if (idade <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A idade não pode ser menor ou igual a zero.");
                Console.ResetColor();
            }
        } while (idade <= 0);

        Leitor leitor = new Leitor(nome, cpf, idade);
        leitores.Add(cpf, leitor);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Leitor cadastrado com sucesso!");
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
            Console.WriteLine($"Nome: {leitor.Nome}, CPF: {leitor.Cpf}, Idade: {leitor.Idade}");
        }
    }

    public static void EditarLeitor()
    {
        Console.Write("Digite o CPF do leitor que deseja editar: ");
        string cpf = Console.ReadLine();

        if (leitores.ContainsKey(cpf))
        {
            Leitor leitor = leitores[cpf];
            Console.WriteLine($"Editando Leitor: {leitor.Nome}");

            Console.Write("Novo nome (deixe em branco para manter o nome atual): ");
            string novoNome = Console.ReadLine();
            if (!string.IsNullOrEmpty(novoNome)) leitor.Nome = novoNome;

            Console.Write("Nova idade (deixe em branco para manter a idade atual): ");
            string novaIdadeStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(novaIdadeStr))
            {
                int novaIdade = int.Parse(novaIdadeStr);
                if (novaIdade > 0) leitor.Idade = novaIdade;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A idade não pode ser menor ou igual a zero.");
                    Console.ResetColor();
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Leitor editado com sucesso!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Leitor não encontrado.");
            Console.ResetColor();
        }
    }

    public static void ExcluirLeitor()
    {
        Console.Write("Digite o CPF do leitor que deseja excluir: ");
        string cpf = Console.ReadLine();

        if (leitores.ContainsKey(cpf))
        {
            leitores.Remove(cpf);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Leitor excluído com sucesso!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Leitor não encontrado.");
            Console.ResetColor();
        }
    }

    public static void CadastrarLivro()
    {
        int codigo;
        while (true)
        {
            try
            {
                Console.Write("Código do Livro: ");
                codigo = int.Parse(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Por favor, insira um número válido para o código do livro.");
                Console.ResetColor();
            }
        }

        Console.Write("Título do Livro: ");
        string titulo = Console.ReadLine();

        Console.Write("Autor do Livro: ");
        string autor = Console.ReadLine();

        Console.Write("Gênero do Livro: ");
        string genero = Console.ReadLine();

        int ano;
        while (true)
        {
            try
            {
                Console.Write("Ano do Livro: ");
                ano = int.Parse(Console.ReadLine());
                if (ano < 1970 || ano > DateTime.Now.Year)
                    throw new ArgumentException("O ano deve estar entre 1970 e o ano atual.");
                break;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Por favor, insira um ano válido.");
                Console.ResetColor();
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        Console.Write("ISBN do Livro: ");
        string isbn = Console.ReadLine();

        int numeroDePaginas;
        while (true)
        {
            try
            {
                Console.Write("Número de Páginas: ");
                numeroDePaginas = int.Parse(Console.ReadLine());
                if (numeroDePaginas <= 0)
                    throw new ArgumentException("O número de páginas deve ser maior que zero.");
                break;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Por favor, insira um número válido para o número de páginas.");
                Console.ResetColor();
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        Livro livro = new Livro(codigo, titulo, autor, genero, ano, isbn, numeroDePaginas);
        livros.Add(codigo, livro);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Livro cadastrado com sucesso!");
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

        foreach (var livro in livros.Values)
        {
            Console.WriteLine(livro.ExibirDados());
        }
    }

    public static void EditarLivro()
    {
        Console.Write("Digite o código do livro que deseja editar: ");
        int codigo = int.Parse(Console.ReadLine());

        if (livros.ContainsKey(codigo))
        {
            Livro livro = livros[codigo];
            Console.WriteLine($"Editando Livro: {livro.Titulo}");

            Console.Write("Novo título (deixe em branco para manter o título atual): ");
            string novoTitulo = Console.ReadLine();
            if (!string.IsNullOrEmpty(novoTitulo)) livro.Titulo = novoTitulo;

            Console.Write("Novo autor (deixe em branco para manter o autor atual): ");
            string novoAutor = Console.ReadLine();
            if (!string.IsNullOrEmpty(novoAutor)) livro.Escritor = novoAutor;

            Console.Write("Novo ano (deixe em branco para manter o ano atual): ");
            string novoAnoStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(novoAnoStr))
            {
                int novoAno = int.Parse(novoAnoStr);
                livro.Ano = novoAno;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Livro editado com sucesso!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Livro não encontrado.");
            Console.ResetColor();
        }
    }

    public static void AtribuirLivroALeitor()
    {
        Console.Write("Digite o CPF do leitor: ");
        string cpfLeitor = Console.ReadLine();

        if (leitores.ContainsKey(cpfLeitor))
        {
            Console.Write("Digite o código do livro a ser atribuído: ");
            int codigoLivro = int.Parse(Console.ReadLine());

            if (livros.ContainsKey(codigoLivro))
            {
                Leitor leitor = leitores[cpfLeitor];
                Livro livro = livros[codigoLivro];
                leitor.AdicionarLivro(livro);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Livro {livro.Titulo} atribuído a {leitor.Nome}.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Livro não encontrado.");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Leitor não encontrado.");
            Console.ResetColor();
        }
    }

    public static void ListarLivrosDeUmLeitor()
    {
        Console.Write("Digite o CPF do leitor: ");
        string cpfLeitor = Console.ReadLine();

        if (leitores.ContainsKey(cpfLeitor))
        {
            Leitor leitor = leitores[cpfLeitor];
            leitor.ExibirLivros();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Leitor não encontrado.");
            Console.ResetColor();
        }
    }

    public static void RemoverLivro()
    {
        Console.Write("Digite o código do livro a ser removido: ");
        int codigo = int.Parse(Console.ReadLine());

        if (livros.ContainsKey(codigo))
        {
            livros.Remove(codigo);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Livro removido com sucesso!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Livro não encontrado.");
            Console.ResetColor();
        }
    }

    public static void DoarLivro()
    {
        Console.Write("Digite o código do livro a ser doado: ");
        int codigo = int.Parse(Console.ReadLine());

        if (livros.ContainsKey(codigo))
        {
            livros.Remove(codigo);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Livro doado com sucesso!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Livro não encontrado.");
            Console.ResetColor();
        }
    }
}
