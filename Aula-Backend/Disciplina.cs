using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula1_17_08
{
    public enum SituacaoAluno
    {
        Pendente, Aprovado, Reprovado, Exame
    }
    public class Disciplina
    {
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public int Cargahoraria { get; set; }
        public SituacaoAluno Situacao { get; set; }

        public List<Aluno> ListAlunos { get; set; }

        public Dictionary<Aluno, double> MapaDeNotas { get; set; }
        public Dictionary<Aluno, int> MapaDeFaltas { get; set; }
        public Dictionary<Aluno, SituacaoAluno> MapaSituacao { get; set; }
        public int Faltas { get; set; }

        public Disciplina(String Nome, int Codigo, int Cargahoraria)
        {
            this.Nome = Nome;
            this.Codigo = Codigo;
            this.Cargahoraria = Cargahoraria;

            ListAlunos = new List<Aluno>();
            MapaDeNotas = new Dictionary<Aluno, double>();
            MapaDeFaltas = new Dictionary<Aluno, int>();
            MapaSituacao = new Dictionary<Aluno, SituacaoAluno>();
        }

        public void LancarNota(Aluno aluno, double np1, double np2, double trabalho)
        {
            double Notafinal = 0;
            Notafinal = (np1 * 0.3) + (np2 * 0.3) + (trabalho * 0.4);
            MapaDeNotas[aluno] = Notafinal;
        }
        public Aluno LocalizarAluno(String strBusca)
        {
            strBusca = strBusca.ToUpper();
            bool isCod = false;
            int cod = -1;
            try
            {
                cod = Convert.ToInt32(strBusca);
                isCod = true;
            }
            catch
            {
                isCod = false;
            }

            if (isCod == true)
            {
                return ListAlunos.First(o => o.Matricula == cod);
            }

            return ListAlunos.First(o => o.Nome.Equals(strBusca));
        }

        public void CadastrarAlunoViaConsole()
        {
            Aluno novoAluno = new Aluno();
            novoAluno.CadastrarAlunoViaConsole();
            if (this.CadastrarAluno(novoAluno))
            {
                Console.WriteLine("Cadastro efetuado com sucesso");
            }
            else
                Console.WriteLine("Erro ao efetuar o cadastro");
        }

        public bool CadastrarAluno(Aluno novoAluno)
        {

            //  for(int i=0; i<ListAlunos.Count; i++)
            //{
            //    if (ListAlunos[i].Nome.Equals(novoAluno.Nome))//aluno já cadastrado
            //        return false; //indica erro ao cadastrar nome já existe
            // }

            novoAluno.Nome = novoAluno.Nome.ToUpper();
            Aluno alunoEncontrado = ListAlunos.FirstOrDefault(aluno => aluno.Nome.Equals(novoAluno.Nome));
            if (alunoEncontrado != null)
                return false;

            ListAlunos.Add(novoAluno);
            MapaDeNotas.Add(novoAluno, 0);
            MapaDeFaltas.Add(novoAluno, 0);
            MapaSituacao.Add(novoAluno,0);

            return true;
        }

        public void AddFalta(Aluno aluno)
        {
            MapaDeFaltas[aluno]++;
        }

        public void ConsultarAprovadoReprovado()
        {
            foreach (KeyValuePair<Aluno, int> alunoatual in MapaDeFaltas)
            {
                int aux = Convert.ToInt32(Cargahoraria / 5);
                if (alunoatual.Value <= aux)//VERIFICANDO AS FALTAS
                {
                    // APROVADO POR FALTAS
                    if (MapaDeNotas[alunoatual.Key] >= 6) // VERIFICANDO A NOTA
                    {
                        //APROVADO por nota
                        alunoatual.Key.Situacao = "Aprovado";
                        Console.WriteLine($"Aluno: {alunoatual.Key.Nome}");
                        Console.WriteLine($"Matricula: {alunoatual.Key.Matricula}");
                        Console.WriteLine($"Curso: {alunoatual.Key.Curso}");
                        Console.WriteLine($"Faltas: {alunoatual.Value}");
                        Console.WriteLine($"Situacao: {alunoatual.Key.Situacao}");
                    }
                    else
                    {
                        alunoatual.Key.Situacao = "Reprovado";
                        Console.WriteLine($"Aluno: {alunoatual.Key.Nome}");
                        Console.WriteLine($"Matricula: {alunoatual.Key.Matricula}");
                        Console.WriteLine($"Curso: {alunoatual.Key.Curso}");
                        Console.WriteLine($"Faltas: {alunoatual.Value}");
                        Console.WriteLine($"Situacao: {alunoatual.Key.Situacao}");
                    }
                }
                else
                {
                    //Reprovado por Falta
                    alunoatual.Key.Situacao = "Reprovado";
                    Console.WriteLine($"Aluno: {alunoatual.Key.Nome}");
                    Console.WriteLine($"Matricula: {alunoatual.Key.Matricula}");
                    Console.WriteLine($"Curso: {alunoatual.Key.Curso}");
                    Console.WriteLine($"Faltas: {alunoatual.Value}");
                    Console.WriteLine($"Situacao: {alunoatual.Key.Situacao}");

                }
            }
        }

    }
}
