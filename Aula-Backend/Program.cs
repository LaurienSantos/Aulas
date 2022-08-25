using System;
using System.Collections.Generic;

namespace Aula1_17_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Disciplina disciplina = new Disciplina("Backend", 777, 20);
            string entrada;
            Aluno aluno;
            do
            {
                Console.Clear();
                Console.WriteLine("Entre com a opcao desejada:");
                Console.WriteLine("1 Cadastrar aluno");
                Console.WriteLine("2 Lancar Nota");
                Console.WriteLine("3 Consultar Nota");
                Console.WriteLine("4 Listar Notas");
                Console.WriteLine("5 Inserir Falta");
                Console.WriteLine("6 Consultar Faltas");
               // Console.WriteLine("7 Listar Aprovados/Reprovados");
                Console.WriteLine("Sair (Para encerrar)");
                entrada = Console.ReadLine();

                switch (entrada)
                {
                    //cadastro
                    case "1":
                        disciplina.CadastrarAlunoViaConsole();

                        break;

                    //lancar nota
                    case "2":
                        try
                        {
                            Console.WriteLine("Entre com Nome ou Matricula do Aluno para lancar nota:");
                            aluno = disciplina.LocalizarAluno(Console.ReadLine());
                            Console.WriteLine($"Localizado: Aluno: {aluno.Nome} Matricula: {aluno.Matricula}");

                            Console.WriteLine("Entre com a nota np1:");
                            double np1 = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine("Entre com a nota np2:");
                            double np2 = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine("Entre com a nota Trabalho:");
                            double trabalho = Convert.ToDouble(Console.ReadLine());

                            disciplina.LancarNota(aluno, np1, np2, trabalho);
                            Console.WriteLine("Nota Final: " + disciplina.MapaDeNotas[aluno]);
                            Console.WriteLine("Nota cadastrada com sucesso! ");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Aluno nao Encontrado!");
                        }
                    
                        break;

                    //consultar nota
                    case "3":
                        Console.WriteLine("Entre com Nome ou Matricula do Aluno para Consulta nota:");
                        aluno = disciplina.LocalizarAluno(Console.ReadLine());
                        Console.WriteLine($" Aluno: {aluno.Nome} Matricula: {aluno.Matricula} Nota Final:  {disciplina.MapaDeNotas[aluno]}");
                        break;

                    //listar nota
                    case "4":
                        Console.WriteLine("Listagem de Notas: ");
                        foreach (KeyValuePair<Aluno, double> alunoAtual in disciplina.MapaDeNotas)
                        {
                            Console.WriteLine($"Aluno: {alunoAtual.Key.Nome} Nota Final: {alunoAtual.Value}");
                        }
                        break;

                    //inserir falta
                    case "5":
                        try
                        {
                            Console.WriteLine("Entre com Nome ou Matricula do Aluno para Consulta nota:");
                            aluno = disciplina.LocalizarAluno(Console.ReadLine());
                            disciplina.AddFalta(aluno);
                            Console.WriteLine("Falta cadastrada com sucesso: ");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Aluno nao Encontrado!");
                        }
                        
                        break;

                    //consultar faltas
                    case "6":
                        Console.WriteLine("Entre com Nome ou Matricula do Aluno para Consulta nota:");
                        aluno = disciplina.LocalizarAluno(Console.ReadLine());
                        Console.WriteLine($"Aluno: {aluno.Nome} Matricula: {aluno.Matricula} Faltas: {disciplina.MapaDeFaltas[aluno]}");
                        break;


                    case "sair":
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção invalida");
                        break;
                }
                Console.ReadKey();

            } while (entrada != "sair");
        }
    }
}
