using System.Runtime.CompilerServices;

namespace Lab1ServSide
{
    internal class Program
    {
        private static List<VideoGame> games = new List<VideoGame>();
        static void Main(string[] args)
        {
            StreamReader sr = new(@"C:\Users\gqfri\source\repos\Lab1ServSide\Lab1ServSide\videogames.csv");
            string header = sr.ReadLine();
            while (sr.ReadLine != null)
            {
                string fileread = sr.ReadLine();
                if (fileread != null)
                {
                    games.Add(ProcessCSVLine(fileread));
                }
            }
            foreach(VideoGame game in games)
            {
                Console.WriteLine(game.ToString());
            }
        }

        static VideoGame ProcessCSVLine(string LineFromCSV)
        {
            string[] rawGameParts = LineFromCSV.Split(",");
            List<string> cleanGameParts = new List<string>();
            string cleanString = string.Empty;
            for (int i = 0; i < rawGameParts.Length; i++)
            {
                cleanString += rawGameParts[i];
                // more data processing / Cleaning?
                cleanGameParts.Add(cleanString);
                cleanString = "";
            }
            string Name = cleanGameParts[0];
            string Platform = cleanGameParts[1];
            string preparse1 = cleanGameParts[2];
            int Year = Int32.Parse(preparse1);
            string Genre = cleanGameParts[3];
            string publisher = cleanGameParts[4];
            string preParse2 = cleanGameParts[5];
            double NASales = double.Parse(preParse2);
            string preParse3 = cleanGameParts[6];
            double EUSales = double.Parse(preParse3);
            string preParse4 = cleanGameParts[7];
            double JPSales = double.Parse(preParse4);
            string preParse5 = cleanGameParts[8];
            double OtherSales = double.Parse(preParse5);
            string preparse6 = cleanGameParts[9];
            double GlobalSales = double.Parse(preparse6);
            VideoGame cleanGame = new VideoGame(Name, Platform, Year, Genre, publisher, NASales, EUSales, JPSales, OtherSales, GlobalSales);
            return cleanGame;
        }
    }
}