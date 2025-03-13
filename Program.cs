class Program
{
    static void Main()
    {
        bool rodando = true;

        while (rodando)
        {
            Console.WriteLine("\t\t\t\t\t biblioteca do zé");
            
            Console.WriteLine("===============================================================================================");
            Console.ForegroundColor=ConsoleColor.Green;
            Console.WriteLine("trabalho feito por : Gabriel Coelho Severino e Leandro Jader");
            Console.ResetColor();
            Console.WriteLine("1. Cadastrar Leitor");
            Console.WriteLine("2. Listar Leitores");
            Console.WriteLine("3. Editar Leitor");
            Console.WriteLine("4. Excluir Leitor");
            Console.WriteLine("5. Cadastrar Livro");
            Console.WriteLine("6. Editar Livro");
            Console.WriteLine("7. atribuir livro a um leior");
            Console.WriteLine("8. Doar Livro");
            Console.WriteLine("9. Listar Livros de um Leitor");
            Console.WriteLine("10. Buscar Livro por Título");
            Console.WriteLine("11. remover livro da biblioteca"); 
            Console.WriteLine("0. Sair");
            Console.ResetColor();

            string opcao = Console.ReadLine();

            switch (opcao)
            {

                case "1":
                Console.Clear();
                    Biblioteca.CadastrarLeitor();
                    break;
                case "2":
                 Console.Clear();
                    Biblioteca.ListarLeitores();
                    break;
                case "3":
                 Console.Clear();
                    Biblioteca.EditarLeitor();
                    break;
                case "4":
                 Console.Clear();
                    Biblioteca.ExcluirLeitor();
                    break;
                case "5":
                 Console.Clear();
                    Biblioteca.CadastrarLivro();
                    break;
                case "6":
                 Console.Clear();
                    Biblioteca.EditarLivro();
                    break;
                case "7":
                 Console.Clear();
                    Biblioteca.AtribuirLivroALeitor();
                    break;
                case "8":
                 Console.Clear();
                    Biblioteca.DoarLivro();
                    break;
                case "9":
                 Console.Clear();
                    Biblioteca.ListarLivrosDeUmLeitor();
                    break;
                case "10":
                 Console.Clear();
                    Biblioteca.BuscarLivroPorTitulo();
                    break;
                case "11":
                 Console.Clear();
                    Biblioteca.RemoverLivro();  
                    break;
                case "0":
                    rodando = false;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção inválida.");
                    Console.ResetColor();
                    break;                              //leandro jader e gabriel coelho severino
            }
        }
    }
}
