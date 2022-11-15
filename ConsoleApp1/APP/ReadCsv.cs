using CsvHelper;
using System.Globalization;

namespace ConsoleApp1
{
    internal class ReadCsv
    {
        public static List<Aluno> ListAlunos = ReadAlunos();
        public static List<Aluno> ReadAlunos()
        {
            List<Aluno> list = new List<Aluno>();
            using (var reader = new StreamReader("Data/Alunos.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                list = csv.GetRecords<Aluno>().ToList<Aluno>();
            }
            return list;
        }
    }
}
