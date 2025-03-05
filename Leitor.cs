using System.Numerics;

public class Leitor {
    public string Nome {get; set;}
    public BigInteger Cpf {get; set;}
    public string Sexo { get; set;}
    public BigInteger Fone {get; set;}
    public string Email {get; set;}

    public Leitor(string nome, BigInteger cpf, string sexo, int fone, string email)
    {
        Nome = nome;
        Cpf = cpf;
        Sexo = sexo;
        Fone = fone;
        Email = email;
    }
}