using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {       
        while (true)
        {
            Console.WriteLine("Bem Vindo a Bibliotéca do Zé!");
            Console.WriteLine("Digite 1 para cadastrar um leitor | 2 para listar os leitores | 3 cadastrar um livro | 4 para listar os livros");
            Console.WriteLine("Digite 5 para vincular um livro a um leitor | 6 para desvincular o livro a um leitor | 7 para sair");
            var Resposta = Console.ReadLine();

            switch (Resposta)
            {
                case "1":
                    FuncoesBiblioteca.CadastrarLeitor();
                    break;
                case "2":
                    FuncoesBiblioteca.Listarleitores();
                    break;
                case "3":
                   FuncoesBiblioteca.CadastrarLivro();
                   break;
                case "4":
                    FuncoesBiblioteca.ListarLivros();
                    break;
                case "5":
                    FuncoesBiblioteca.VincularLivro();
                    break;
                case "6":
                    FuncoesBiblioteca.DesvincularLivro();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Saindo...");
                    break; 
            }   
        }
    }
}