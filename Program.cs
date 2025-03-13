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
            Console.WriteLine("criado por: gabriel coelho severino e leandro jader");
            Console.ResetColor();
            Console.WriteLine("1. Cadastrar Leitor");
            Console.WriteLine("2. Listar Leitores e seus Livros");
            Console.WriteLine("3. Editar Leitor");
            Console.WriteLine("4. Excluir Leitor");
            Console.WriteLine("5. cadastrar livro");
            Console.WriteLine("6. editar livro");
            Console.WriteLine("7. remover livro");
            Console.WriteLine("8. doar livro");
            Console.WriteLine("9. Listar Livros de um Leitor Específico");
            Console.WriteLine("10. Buscar Livro por Título");
            Console.WriteLine("11. Sair");
            Console.Write("Escolha uma opção: ");

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
                    Biblioteca.RemoverLivro();
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
                    rodando = false;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
