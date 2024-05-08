using System;
using System.Collections.Generic;

// Definição da classe Aluno
public class Aluno
{
    // Atributos
    private string nome;
    private int idade;
    private Turma turma; // Associação bidirecional com a classe Turma

    // Propriedades
    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public int Idade
    {
        get { return idade; }
        set { idade = value; }
    }

    public Turma Turma
    {
        get { return turma; }
        set { turma = value; }
    }

    // Método
    public void Estudar()
    {
        Console.WriteLine($"{Nome} está estudando...");
    }

    // Sobrecarga de Método
    public void Estudar(string disciplina)
    {
        Console.WriteLine($"{Nome} está estudando {disciplina}...");
    }
}

// Definição da classe Professor
public class Professor
{
    // Atributos
    private string nome;
    private string disciplina;

    // Propriedades
    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public string Disciplina
    {
        get { return disciplina; }
        set { disciplina = value; }
    }

    // Método
    public void Ensinar()
    {
        Console.WriteLine($"{Nome} está ensinando {Disciplina}...");
    }

    // Sobrecarga de Método
    public void Ensinar(string turma)
    {
        Console.WriteLine($"{Nome} está ensinando a turma {turma}...");
    }
}

// Definição da classe Turma
public class Turma
{
    // Atributos
    private string nome;
    private List<Aluno> alunos;

    // Propriedade
    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    // Propriedade para acessar a lista de alunos
    public List<Aluno> Alunos
    {
        get { return alunos; }
    }

    // Construtor
    public Turma()
    {
        alunos = new List<Aluno>();
    }

    // Método para adicionar aluno à turma
    public void AdicionarAluno(Aluno aluno)
    {
        aluno.Turma = this; // Estabelecendo a associação bidirecional
        alunos.Add(aluno);
        Console.WriteLine($"{aluno.Nome} foi adicionado à turma {Nome}.");
    }

    // Método para exibir os alunos da turma
    public void ExibirAlunos()
    {
        Console.WriteLine($"Alunos da turma {Nome}:");
        foreach (var aluno in alunos)
        {
            Console.WriteLine($"- {aluno.Nome}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criando objetos Aluno, Professor e Turma
        Aluno aluno1 = new Aluno { Nome = "João", Idade = 20 };
        Aluno aluno2 = new Aluno { Nome = "Claudio", Idade = 19 };
        Professor professor1 = new Professor { Nome = "Maria", Disciplina = "Matemática" };
        Professor professor2 = new Professor { Nome = "Joana", Disciplina = "Português" };
        Turma turma1 = new Turma { Nome = "Turma de Matemática" };
        Turma turma2 = new Turma { Nome = "Turma de Português" };

        // Adicionando aluno à turma
        turma1.AdicionarAluno(aluno1);
        turma2.AdicionarAluno(aluno2);

        // Chamando métodos
        aluno1.Estudar();
        aluno1.Estudar("Matemática");
        professor1.Ensinar();
        professor1.Ensinar("Turma de Matemática");
        turma1.ExibirAlunos();
        aluno2.Estudar();
        aluno2.Estudar("Português");
        professor2.Ensinar();
        professor2.Ensinar("Turma de Português");
        turma2.ExibirAlunos();
    }
}
