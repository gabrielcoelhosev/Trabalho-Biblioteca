using System.Numerics;

public static class FuncoesBiblioteca
{
    public static void CadastrarLeitor()
    {
        BigInteger cpf;

        Console.WriteLine("Digite um nome para o leitor");
        String nome = Console.ReadLine();
        Console.WriteLine("Digite um CPF do leitor");
        BigInteger.TryParse(Console.ReadLine(), out cpf);

        Leitor leitor1 = new Leitor(nome, cpf);

        Console.WriteLine($"Nome: {leitor1.Nome}, Cpf: {leitor1.Cpf}");
    }
}