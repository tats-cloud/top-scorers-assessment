class Program
{
    static void Main()
    {
        Console.Write("Enter file path: ");
        string? filePath = Console.ReadLine();

        while (!File.Exists(filePath))
        {
            Console.WriteLine("File not found. Please try again.");
            filePath = Console.ReadLine();
        }

        Console.Write("Enter your file delimiter: ");
        string? delimiter = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(delimiter))
        {
            Console.WriteLine("Please enter a valid delimiter.");
            delimiter = Console.ReadLine();
        }

        var topScorers = new List<string>();
        var maxScore = -1;

        try
        {
            using StreamReader reader = File.OpenText(filePath);

            string? line;

            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var lineParts = line.Split(delimiter.Trim());

                if (lineParts.Length != 3) continue;

                var fullName = $"{lineParts[0]} {lineParts[1]}";

                if (int.TryParse(lineParts[2].Trim(), out int score))
                {
                    if (score > maxScore)
                    {
                        maxScore = score;
                        topScorers.Clear();
                        topScorers.Add(fullName);
                    }
                    else if (score == maxScore)
                    {
                        topScorers.Add(fullName);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            return;
        }

        topScorers.Sort();

        foreach (var scorer in topScorers)
        {
            Console.WriteLine(scorer);
        }

        Console.WriteLine($"Score: {maxScore}");
    }
}
