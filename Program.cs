using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {       
        while (true)
        {
            Console.WriteLine("Bem Vindo a Bibliotéca do Zé!");
            Console.WriteLine("Digite 1 para cadastrar um leitor | 2 para listar os livros de um leitor | 3 para deletar o livro de um leitor | 4 para sair");
            var Resposta = Console.ReadLine();

            switch (Resposta)
            {
                case "1":
                    //CadastrarLeitor();
                    break;
                case "2":
                    //ListarLivros();
                    break;
                case "3":
                   //DeletarLivro();
                   break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Saindo...");
                    break; 
            }   
        }
    }
}