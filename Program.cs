LogService service = new LogService();
service.LoadFromFile("events.txt");

while (true)
{
    Console.WriteLine("1 - Show all logs");
    Console.WriteLine("2 - Filter logs");
    Console.WriteLine("3 - Show statistics");
    Console.WriteLine("4 - Save report");
    Console.WriteLine("5 - Quit");

    string? choice = Console.ReadLine();

    if (choice == "1")
    {
    foreach (LogEntry log in service.GetAll())
        {
            Console.WriteLine ($"{log.Level} | {log.Source} | {log.Message}");
        }
    } 
    else if (choice == "2")
    {
            Console.WriteLine("Enter Level: ");
            string? level = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(level))
        {
            List<LogEntry> matchingLogs = service.GetByLevel(level);

            foreach (LogEntry log in matchingLogs)
            {
            Console.WriteLine($"Log: {log.Level}");
            Console.WriteLine($"Log: {log.Source}");
            Console.WriteLine($"Log: {log.Message}");
            }
        }
    } 
    else if (choice == "3")
    {
        Console.WriteLine($"Total logs: {service.GetTotalCount()}");
        Console.WriteLine($"Info logs: {service.GetCountByLevel("INFO")}");
        Console.WriteLine($"Error logs: {service.GetCountByLevel("ERROR")}");
        Console.WriteLine($"Warning logs: {service.GetCountByLevel("WARNING")}");
        Console.WriteLine($"Contains errors: {service.HasErrors()}");
    } 
    else if (choice == "4")
    {
        service.SaveReport("report.txt");
        Console.WriteLine("Report saved to report.txt!");
    } 
    else if (choice == "5")
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice");
    }
}

public class LogEntry
{
    public string Level { get; set; }
    public string Source { get; set; }
    public string Message { get; set; }

        public LogEntry(string level, string source, string message)
        {
        Level = level;
        Source = source;
        Message = message;
        }
}