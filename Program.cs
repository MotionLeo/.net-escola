// See https://aka.ms/new-console-template for more information
namespace Escola;

class Program
{
    static void Main(string[] args)
    {
        var alunos = new List<Aluno>();

        int opc = 0;

        
        while(true)
        {
            Console.Clear();
            Console.WriteLine("Por favor, digite as opções abaixo: \n1- Cadastrar aluno" +
                        "\n2- Listar alunos\n3- Sair");
            int.TryParse(Console.ReadLine(), out opc);

            switch(opc)
            {
                case 1:
                    cadastrarAluno(alunos);
                    
                    break;

                case 2:
                    listarAlunos(alunos);
                    break;  

                case 3:
                    Console.WriteLine("Saindo do sistema...");
                    return;

                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    Thread.Sleep(2000);
                    break;
            }

        }
    }

    private static void cadastrarAluno(List<Aluno> alunos)
    {
        var aluno = new Aluno();
        
        Console.Clear();
        //Pegando dados do aluno novo
        Console.WriteLine("Digite o nome do aluno: ");
        aluno.Nome = Console.ReadLine();
        Console.WriteLine("Digite a matrícula do aluno: ");
        aluno.Matricula = Console.ReadLine();
        Console.WriteLine("Digite as notas do aluno separadas por vírgula: ");
        var sNotas = Console.ReadLine();

        //Separando as notas para formar um array de nota
        var sArrayNotas = sNotas.Split(',');
        var listaNotas = new List<double>();
        foreach(var sNota in sArrayNotas)
        {
            double nota = 0;
            double.TryParse(sNota, out nota);
            listaNotas.Add(nota);
        }

        //Adicionando aluno novo
        aluno.Notas = listaNotas;
        alunos.Add(aluno);

        Console.Clear();
        Console.WriteLine("Aluno cadastrado com sucesso!");
        Thread.Sleep(2000);
    }

    private static void listarAlunos(List<Aluno> alunos)
    {
        Console.Clear();

        //Verificando se existem alunos
        if(alunos.Count == 0)
        {
            Console.WriteLine("Nenhum aluno cadastrado!");
            Thread.Sleep(2000);
            return;
        }

        //Exibindo cada aluno, um por um através de um foreach com média e se foi aprovado
        foreach(var aluno in alunos)
        {
            Console.WriteLine("---------------");
            Console.WriteLine($"Nome: {aluno.Nome}\nMatrícula: {aluno.Matricula}\nNotas: {aluno.NotasFormatadas()}");
            Console.WriteLine($"Média das notas: {aluno.Media().ToString("#.##")}");
            Console.WriteLine($"Situação: {aluno.Situacao()}");
            Console.WriteLine("---------------");
        }
        Thread.Sleep(5000);
    }

}
