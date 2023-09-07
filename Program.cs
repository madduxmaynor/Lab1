using Lab1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        List<VideoGame> games = LoadGamesFromCsv();
        PublisherData(games);
        GenreData(games);
    }
    static void PublisherData(List<VideoGame> games)
    {
        Console.Write("Enter a publisher: ");
        string publisher = Console.ReadLine();

            List<string> validPublishers = new List<string>
            {
                   "Ubisoft", "Sega", "Electronic Arts", "Sony Computer Entertainment","Role-Playing", "Nintendo"
            };

            if (!validPublishers.Contains(publisher, StringComparer.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Sorry, '{publisher}' is not a valid publisher. Please enter a valid publisher.");
                return;
            }

        var publisherGames = games.Where(game => game.Publisher.Equals(publisher, StringComparison.OrdinalIgnoreCase)).ToList();

            if (publisherGames.Count == 0)
            {
                Console.WriteLine($"No games found for {publisher}");
                return;
            }

            foreach (var game in publisherGames)
            {
                Console.WriteLine(game);
            }
        publisherGames = publisherGames.OrderBy(game => game.Name).ToList();
        int GameNum = 16327;
        double percentage = (double)publisherGames.Count / games.Count * 100;
        Console.WriteLine($"Out of {GameNum} games, {publisherGames.Count} are developed by {publisher}, which is {percentage}%");
        // I cant get the percintage to be 2 decimal places out please be gental
    }
    static void GenreData(List<VideoGame> games)
    {
        Console.Write("Enter a genre please: ");
        string genre = Console.ReadLine();

        List<string> validGenres = new List<string>
        {
            "Action", "Shooter", "Role-Playing", "Sports", "Adventure", 
        };

            if (!validGenres.Contains(genre, StringComparer.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Sorry, '{genre}' is not a valid genre. Please enter a valid genre.");
                return;
            }

        var genreGames = games.Where(game => game.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();

            if (genreGames.Count == 0)
            {
                Console.WriteLine($"No games found in the {genre} genre");
                return;
            }

            foreach (var game in genreGames)
            {
                Console.WriteLine(game);
            }
        genreGames = genreGames.OrderBy(game => game.Name).ToList();
        int GameNum = 16327;
        double percentage = (double)genreGames.Count / games.Count * 100;
        Console.WriteLine($"Out of {GameNum} games, {genreGames.Count} are in the {genre} genre, which is {percentage}%");

    }

    static List<VideoGame> LoadGamesFromCsv()
    {
        string filepath = @"C:\\Users\\maddu\\source\\repos\\Lab1\\Lab1\\videogames (1).csv";

        List<VideoGame> games = File.ReadLines(filepath)
            .Skip(1)
            .Select(line =>
            {
            var values = line.Split(',');
                return new VideoGame
                {
                    Name = values[0],
                    Platform = values[1],
                    Year = int.Parse(values[2]),
                    Genre = values[3],
                    Publisher = values[4],
                    NA_Sales = double.Parse(values[5]),
                    EU_Sales = double.Parse(values[6]),
                    JP_Sales = double.Parse(values[7]),
                    Other_Sales = double.Parse(values[8]),
                    Global_Sales = double.Parse(values[9])
                };
            })
            .ToList();

        return games;
    }
}


