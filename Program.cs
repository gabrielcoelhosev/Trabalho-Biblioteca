using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {       
        while (true)
        
        {
            
            Console.WriteLine("\t \t \t \t \t \t Bem Vindo a Bibliotéca do Zé!");
            Console.WriteLine("==================================================================================================================");
            Console.WriteLine("Digite (1) para cadastrar um leitor");
            Console.WriteLine("=========================");
            Console.WriteLine("(2) para listar os leitores");
            Console.WriteLine("==========================");
            Console.WriteLine("(3) para cadastrar um livro ");
            Console.WriteLine("==========================");
            Console.WriteLine("(4) para listar os livros ");
            Console.WriteLine("==========================");
            Console.WriteLine("(5) para vincular um livro a um leitor");
            Console.WriteLine("==========================");
            Console.WriteLine("(6) para desvincular o liro de um leiotr ");
            Console.WriteLine("==========================");
            Console.WriteLine("(7) para doar um livro ");
            Console.WriteLine("==========================");
            Console.WriteLine("(8) para sair ");
            Console.WriteLine("==========================");

            var Resposta = Console.ReadLine();

            switch (Resposta)
            {
                case "1":
                Console.Clear();
                    FuncoesBiblioteca.CadastrarLeitor();
                    break;
                
                case "2":
                 Console.Clear();
                    FuncoesBiblioteca.Listarleitores();
                    break;
                case "3":
                Console.Clear();
                   FuncoesBiblioteca.CadastrarLivro();
                   break;
                case "4":
                Console.Clear();
                    FuncoesBiblioteca.ListarLivros();
                    break;
                case "5":
                Console.Clear();
                    FuncoesBiblioteca.VincularLivro();
                    break;
                case "6":
                Console.Clear();
                    FuncoesBiblioteca.DesvincularLivro();
                    break;
                case "7":
                Console.Clear();
                    FuncoesBiblioteca.DoarLivro();
                    break;
                    Console.Clear();
                case "8":
                    return;
                default:
                    Console.WriteLine("Saindo...");
                    break; 
            } 
           
        }
    }
}