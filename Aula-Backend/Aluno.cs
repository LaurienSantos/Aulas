using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula1_17_08
{
    public class Aluno
    {
        public static int _matriculaBase = 1;
        public String Nome { get; set; }
        public int Matricula { get; set; }
        public String Curso { get; set; }
        public String Falta { get; set; }
        public String Situacao { get; set; }

        public void CadastrarAlunoViaConsole()
        {
            Console.WriteLine("Entre com nome do Aluno: ");
            this.Nome = Console.ReadLine().ToUpper();
            this.Situacao = "Pendente";
            this.Matricula = _matriculaBase;
            _matriculaBase++;
        }

        public void AddFalta()
        {
            Console.WriteLine("Entre com a Falta: ");
            this.Falta = Console.ReadLine();
        }
    }
}
