using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {       
        while (true)
        {
            Console.WriteLine("\t \t \t \t \t \t Bem Vindo a Bibliotéca do Zé!");
            Console.WriteLine("==================================================================================================================");
            Console.WriteLine("Digite 1 para cadastrar um leitor \t 2 para listar os leitores \t 3 cadastrar um livro \t 4 para listar os livros");
            Console.WriteLine("");
            Console.WriteLine("Digite 5 para vincular um livro a um leitor \n 6 para desvincular o livro a um leitor \n 7 para doar um livro \n 8 para sair");
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
                    FuncoesBiblioteca.DoarLivro();
                    break;
                case "8":
                    return;
                default:
                    Console.WriteLine("Saindo...");
                    break; 
            }   
        }
    }
}