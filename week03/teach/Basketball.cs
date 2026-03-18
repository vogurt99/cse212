/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        string path = "/home/samuel/School/Code/CSE 212/cse212/week03/teach/basketball.csv";
        using var reader = new TextFieldParser(path);

        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields();
        
        while (!reader.EndOfData) {
            var fields = reader.ReadFields();
            if (fields == null) continue;

            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            // Adds points to the player's total in the dictionary.
            if (players.ContainsKey(playerId))
            {
                players[playerId] += points;
            }
            else
            {
                players[playerId] = points;
            }
        }

        // Convert the dictionary to an array of KeyValuePairs for sorting.
        var playerArray = players.ToArray();

        // Sort the array in descending order based on points.
        Array.Sort(playerArray, (p1, p2) => p2.Value.CompareTo(p1.Value));

        // Top 10 players with the most points.
        Console.WriteLine("Top 10 Career Points:");
        for (int i = 0; i < 10 && i < playerArray.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {playerArray[i].Key}: {playerArray[i].Value}");
        }
    }
}