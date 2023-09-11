using System.Runtime.CompilerServices;

namespace Lab1ServSide
{
    internal class Program
    {
        private static List<VideoGame> games = new List<VideoGame>();
        static void Main(string[] args)
        {
            StreamReader sr = new(@"C:\Users\Gavin Frisby\Source\Repos\Lab1ServSide\Lab1ServSide\videogames.csv");
            string header = sr.ReadLine();
            string NullCheck;
            while ((NullCheck = sr.ReadLine()) != null) 
            {   
                    games.Add(ProcessCSVLine(NullCheck));                   
            }
            string userChoice;
            do {
                //foreach (VideoGame game in games)
                //{
                //    System.Console.WriteLine(game.Name);
                //}
                Console.WriteLine("Number of Games: " + games.Count);
                Console.Write("Please Select Action");
                Console.WriteLine();
                Console.WriteLine("Alphabetical Order (1)");
                Console.WriteLine("Manual Nintendo Search (2)");
                Console.WriteLine("Manual Racing Search (3)");
                Console.WriteLine("Custom Publisher Search (4)");
                Console.WriteLine("Custom Genre Search (5)");
                Console.WriteLine("Stop (6)");
                userChoice = Console.ReadLine();
                if (userChoice.Equals("1"))
                {
                    // Ascending Order
                    games.Sort((a, b) => a.CompareTo(b));
                    foreach (VideoGame game in games)
                    {
                        Console.WriteLine(game.ToString());
                    }
                }

                if (userChoice.Equals("2"))
                    // check numbers?
                {
                    // Sorts by publisher
                    string nintendo = "Nintendo";
                    List<VideoGame> NintendoGames = games.Where(x => x.Publisher == nintendo).ToList();
                    NintendoGames.Sort((a, b) => a.CompareTo(b));
                    foreach (VideoGame game in NintendoGames)
                    {
                        Console.WriteLine(game.ToString());
                    }

                    double PublishPercent = (double)NintendoGames.Count() / (double)games.Count() * 100;
                    Console.WriteLine("Out of " + games.Count() + " games, " + NintendoGames.Count() + " are developed by Nintendo, " + "which is " + Math.Round(PublishPercent, 2) + "%");
                }

                if (userChoice.Equals("3"))
                {
                    string racing = "Racing";
                    List<VideoGame> RacingGames = games.Where(x => x.Genre == racing).ToList();
                    RacingGames.Sort((a, b) => a.CompareTo(b));
                    foreach (VideoGame game in RacingGames)
                    {
                        Console.WriteLine(game.ToString());
                    }

                    double PublishPercent = (double)RacingGames.Count() / (double)games.Count() * 100;
                    Console.WriteLine("Out of " + games.Count() + " games, " + RacingGames.Count() + " are Racing Games, " + "which is " + Math.Round(PublishPercent, 2) + "%");
                }

                if(userChoice.Equals("4"))
                {
                    PublisherData();
                }

                if(userChoice.Equals("5"))
                {
                    GenreData();
                }
            } while (userChoice != "6");
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
        static void PublisherData()
        {
            Console.WriteLine("Please Enter the Publisher you would like to search: ");
            string publisher = Console.ReadLine();
            if (publisher == "")
            {
                publisher = "Blank";
            }
            List<VideoGame> SearchedGames = games.Where(x => x.Publisher == publisher).ToList();
            SearchedGames.Sort((a, b) => a.CompareTo(b));
            foreach (VideoGame game in SearchedGames)
            {
                Console.WriteLine(game.ToString());
            }
            double PublishPercent = (double)SearchedGames.Count() / (double)games.Count() * 100;
            Console.WriteLine("Out of " + games.Count() + " games, " + SearchedGames.Count() + " are developed by " + publisher + ", which is " + Math.Round(PublishPercent, 2) + "%");
        }

        static void GenreData()
        {
            Console.WriteLine("Please Enter the Genre you would like to search: ");
            string Genre = Console.ReadLine();
            if (Genre == "")
            {
                Genre = "Blank";
            }
            List<VideoGame> SearchedGames = games.Where(x => x.Genre == Genre).ToList();
            SearchedGames.Sort((a, b) => a.CompareTo(b));
            foreach (VideoGame game in SearchedGames)
            {
                Console.WriteLine(game.ToString());
            }
            double PublishPercent = (double)SearchedGames.Count() / (double)games.Count() * 100;
            Console.WriteLine("Out of " + games.Count() + " games, " + SearchedGames.Count() + " are " + Genre + " games, which is " + Math.Round(PublishPercent, 2) + "%");
        }
    }
}
