using System;
using System.Collections.Generic;

class Leitor
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public List<Livro> Livros { get; set; }

    public Leitor(string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
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
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Livros de {Nome} (CPF: {Cpf}):");
        Console.ResetColor();

        if (Livros.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nenhum livro cadastrado.");
            Console.ResetColor();
        }
        else
        {
            foreach (var livro in Livros)                           //leandro jader e gabriel coelho
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"- {livro.Titulo} ({livro.Ano}) - Autor: {livro.Escritor}");
                Console.ResetColor();
            }
        }               
        
    }
}                           
