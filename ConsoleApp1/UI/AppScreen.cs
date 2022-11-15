using ConsoleApp1.APP;

namespace ConsoleApp1.UI
{
    internal class AppScreen
    {
        public static void WelcomeMenu()
        {
            Console.Clear();
            Console.WriteLine("Seja Bem-vindo(a)!");
            Utilities.PrintLine();
            Console.WriteLine("Selecione a opção desejada:");
            Console.WriteLine("1 - Alunos aprovados e reprovados");
            Console.WriteLine("2 - Melhor estudante por matéria");
            Console.WriteLine("3 - Melhor estudante geral");
            Console.WriteLine("4 - Pior estudante geral");
            Console.WriteLine("5 - Informações de um(a) estudante pela matrícula");
            Utilities.PrintLine();
            Console.WriteLine("Digite o número da opção desejada:");
            
            switch(Console.ReadLine())
            {
                case "1":
                    DisplayStudentResults();
                    break;
                case "2":
                    DisplayBestStudentInClassMenu();
                    break;
                case "3":
                    DisplayBestOverall();
                    break;
                case "4":
                    DisplayWorstOverall();
                    break;
                case "5":
                    DisplayStudentById();
                    break;
                default: 
                    Utilities.PrintLine();
                    Console.WriteLine("Opção inválida");
                    Utilities.ReturnToMainMenuPrompt(); 
                    break;
            }
        }

        private static void DisplayStudentById()
        {
            Console.Clear();
            Console.WriteLine("Digite o número da matrícula do usuário:");
            int id;

            try
            {
               id  = int.Parse(Console.ReadLine());
            }
            catch
            {
                Utilities.PrintLine();
                Console.WriteLine("Estudante não encontrado, tente novamente.");
                Utilities.ReturnToMainMenuPrompt();
                return;
            }
            
            Aluno? pickedAluno = null;
            foreach (Aluno aluno in ReadCsv.ListAlunos)
            {
                if (aluno.Matricula == id)
                    pickedAluno = aluno;
            }
            if(pickedAluno == null) {

                Utilities.PrintLine();
                Console.WriteLine("Estudante não encontrado, tente novamente.");
                Utilities.ReturnToMainMenuPrompt();
                return;
            }
            Console.Clear();
            Utilities.PrintLine();
            Utilities.PrintRow(pickedAluno.Nome);
            Utilities.PrintLine();
            Utilities.PrintRow("Matrícula", "Matemática","Português","História");
            Utilities.PrintLine();
            Utilities.PrintRow(
                pickedAluno.Matricula.ToString(),
                pickedAluno.Matematica.ToString(),
                pickedAluno.Portugues.ToString(),
                pickedAluno.Historia.ToString()
            );
            Utilities.PrintLine();
            Utilities.ReturnToMainMenuPrompt();
        }

        private static void DisplayWorstOverall()
        {
            Aluno aluno = GradeOperations.WorstOverall();
            Console.Clear();
            Console.WriteLine("O(a) pior estudante geral foi:");
            Utilities.PrintLine();
            Console.WriteLine(aluno.Nome + " com a média de " + aluno.Average + " pontos.");
            Utilities.PrintLine();
            Utilities.ReturnToMainMenuPrompt();
        }

        private static void DisplayBestOverall()
        {
            Aluno aluno = GradeOperations.BestOverall();
            Console.Clear();
            Console.WriteLine("O(a) melhor estudante geral foi:");
            Utilities.PrintLine();
            Console.WriteLine(aluno.Nome + " com a média de " + aluno.Average + " pontos.");
            Utilities.PrintLine();
            Utilities.ReturnToMainMenuPrompt();
        }

        private static void DisplayBestStudentInClassMenu()
        {
            Aluno aluno;

            Console.Clear();
            Console.WriteLine("Selecione a opção");
            Console.WriteLine("1 - Matemática");
            Console.WriteLine("2 - Português");
            Console.WriteLine("3 - História");
            Console.WriteLine("Digite o número da opção desejada:");
            var input = Console.ReadLine();
            Console.Clear();
            switch (input)
            {
                case "1":
                    aluno = GradeOperations.BestInMath();
                    Console.WriteLine("O(a) melhor estudante em Matemática foi:");
                    Utilities.PrintLine();
                    Console.WriteLine(aluno.Nome + " com " + aluno.Matematica + " pontos.");
                    break;
                case "2":
                    aluno = GradeOperations.BestInPortuguese();
                    Console.WriteLine("O(a) melhor estudante em Português foi:");
                    Utilities.PrintLine();
                    Console.WriteLine(aluno.Nome + " com " + aluno.Portugues + " pontos.");
                    break;
                case "3":
                    aluno = GradeOperations.BestInHistory();
                    Console.WriteLine("O(a) melhor estudante em História foi:");
                    Utilities.PrintLine();
                    Console.WriteLine(aluno.Nome + " com " + aluno.Historia + " pontos.");
                    break;
                default :
                    Utilities.PrintLine();
                    Console.WriteLine("Opção inválida");
                    Utilities.ReturnToMainMenuPrompt();
                    return;
            }
            Utilities.PrintLine();
            Utilities.ReturnToMainMenuPrompt();
        }


        private static void DisplayStudentResults()
        {
            var passed = new List<Aluno>();
            var failed = new List<Aluno>();

            foreach(Aluno aluno in ReadCsv.ListAlunos)
            {
                if (aluno.Passed)
                {
                    passed.Add(aluno);
                }
                else
                {
                    failed.Add(aluno);
                }
            }
            Console.Clear();
            Utilities.PrintLine();
            Utilities.PrintRow("Aprovados", "Reprovados");
            Utilities.PrintLine();
            int limit = passed.Count>failed.Count?passed.Count:failed.Count;
            for (int i = 0; i < limit; i++)
            {
                string arg1 = "", arg2 = "";
                arg1 = i < passed.Count ? passed[i].Nome : "";
                arg2 = i < failed.Count ? failed[i].Nome : "";
                Utilities.PrintRow(arg1,arg2);
                Utilities.PrintLine();
            }
            Utilities.ReturnToMainMenuPrompt();
        }
    }
}
