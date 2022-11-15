namespace ConsoleApp1.APP
{
    public static class GradeOperations
    {
        private static List<Aluno> _listAlunos = ReadCsv.ListAlunos;
        public static List<Aluno> PassedStudents()
        {
            var passed = new List<Aluno>();
            foreach (Aluno aluno in _listAlunos)
            {
                if (aluno.Passed)
                {
                    passed.Add(aluno);
                }
            }
            return passed;
        }

        public static Aluno BestOverall()
        {
            var best = new Aluno();
            foreach (Aluno aluno in _listAlunos)
            {
                if (aluno.Average > best.Average)
                {
                    best = aluno;
                }
            }
            return best;
        }
        public static Aluno WorstOverall()
        {
            var worst = _listAlunos[0];
            foreach (Aluno aluno in _listAlunos)
            {
                if (aluno.Average < worst.Average)
                {
                    worst = aluno;
                }
            }
            return worst;
        }

        public static Aluno BestInMath()
        {
            Aluno best = new Aluno();
            foreach (Aluno aluno in _listAlunos)
            {
                if (aluno.Matematica > best.Matematica)
                {
                    best = aluno;
                }
            }
            return best;
        }

        public static Aluno BestInHistory()
        {
            Aluno best = new Aluno();
            foreach (Aluno aluno in _listAlunos)
            {
                if (aluno.Historia > best.Historia)
                {
                    best = aluno;
                }
            }
            return best;
        }

        public static Aluno BestInPortuguese()
        {
            Aluno best = new Aluno();
            foreach (Aluno aluno in _listAlunos)
            {
                if (aluno.Portugues > best.Portugues)
                {
                    best = aluno;
                }
            }
            return best;
        }
    }
}
