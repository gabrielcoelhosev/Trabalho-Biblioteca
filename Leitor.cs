using System;
using System.Collections.Generic;

public class Leitor
{
    private string nome;
    private string cpf;
    private int idade;

    public List<Livro> Livros { get; private set; }

    public string Nome
    {
        get { return nome; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Nome não pode ser vazio ou nulo.");
            nome = value.Trim();
        }
    }

    public string Cpf
    {
        get { return cpf; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("CPF não pode ser vazio ou nulo.");
            if (Biblioteca.VerificarCpfExistente(value))
                throw new ArgumentException("CPF já está cadastrado.");
            cpf = value.Trim();
        }
    }

    public int Idade
    {
        get { return idade; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Idade não pode ser negativa.");
            idade = value;
        }
    }

    public Leitor(string nome, string cpf, int idade)
    {
        Nome = nome;
        Cpf = cpf;
        Idade = idade;
        Livros = new List<Livro>();
    }

    public void AdicionarLivro(Livro livro)
    {
        Livros.Add(livro);
    }

    public void RemoverLivro(Livro livro)
    {
        Livros.Remove(livro);
    }

    public void ExibirLivros()
    {
        if (Livros.Count == 0)
        {
            Console.WriteLine("Nenhum livro associado a este leitor.");
        }
        else
        {
            Console.WriteLine($"Livros de {Nome}:");
            foreach (var livro in Livros)
            {
                livro.ExibirDados();
            }
        }
    }
}
