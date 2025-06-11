public class Program
{
    public static void Main()
    {
        var processor = new CommandProcessor();
        string? line;
        while ((line = Console.ReadLine()) != null)
        {
            if (line.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
                break;
            processor.Process(line);
        }
    }
}
