public class Program
{
    private static void Main(string[] args)
    {
        Livro livro1 = new Livro(
            "Harry Potter",
            "E a pedra filosofal",
            "J.K Rowling",
            "Rocco",
            "Fantasia",
            1997,
            "Dura",
            208
        );

        Console.WriteLine(livro1.Titulo);
    }
}