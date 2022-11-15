
namespace ConsoleApp1.UI
{
    internal class Utilities
    {
        private static int tableWidth = 100;
        public static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        private static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
        public static void ReturnToMainMenuPrompt()
        {
            Console.WriteLine("Pressione >Enter< para voltar ao menu principal...");
            Console.ReadLine();
            AppScreen.WelcomeMenu();
        }
    }
}
