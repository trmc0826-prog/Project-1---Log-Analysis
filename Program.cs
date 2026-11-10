LogService service = new LogService();

service.LoadFromFile("events.txt");

if (!File.Exists("events.txt"))
    {
        return;
    }

while (true)
{
    Console.WriteLine("1 - Show all logs");
    Console.WriteLine("2 - Filter logs");
    Console.WriteLine("3 - Show statistics");
    Console.WriteLine("4 - Save report");
    Console.WriteLine("5 - Sort Logs by Source");
    Console.WriteLine("6 - Quit");

    string? choice = Console.ReadLine();

    if (choice == "1")
    {
    foreach (LogEntry log in service.GetAll())
    {
    Console.WriteLine($"{log.Level} | {log.Source} | {log.Message}");
    }
    }
    else if (choice == "2")
    {
    Console.WriteLine("1 - Filter by Level");
    Console.WriteLine("2 - Filter by Source");
    Console.WriteLine("3 - Search by Message");

    string? filterChoice = Console.ReadLine();

    if (filterChoice == "1")
    {
        Console.WriteLine("Enter Level: ");
        string? level = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(level))
        {
            List<LogEntry> matchingLogs = service.GetByLevel(level);
            if (matchingLogs.Count == 0)
            {
                Console.WriteLine("No matching log was found.");
            }
                foreach (LogEntry log in matchingLogs)
                {
                    Console.WriteLine($"Log: {log.Level}");
                    Console.WriteLine($"Log: {log.Source}");
                    Console.WriteLine($"Log: {log.Message}");
                }
        }
        else
        {
            Console.WriteLine("Please enter a valid Level: ");
        }
    }
        else if (filterChoice == "2")
        {
            Console.WriteLine("Enter Source:");
            string? source = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(source))
            {
                List<LogEntry> matchingLogs = service.GetBySource(source);
                if (matchingLogs.Count == 0)
                    {
                        Console.WriteLine("No matching log was found.");
                    }
                foreach (LogEntry log in matchingLogs)
                {
                    Console.WriteLine($"Log: {log.Level}");
                    Console.WriteLine($"Log: {log.Source}");
                    Console.WriteLine($"Log: {log.Message}");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid source: ");
            }
        }
    else if (filterChoice == "3")
    {
        Console.WriteLine("Enter message text: ");
        string? text = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(text))
        {
                List<LogEntry> matchingLogs = service.SearchByMessage(text);
                if (matchingLogs.Count == 0)
                {
                        Console.WriteLine("No matching log was found.");
                }
                foreach (LogEntry log in matchingLogs)
                {
                    Console.WriteLine($"Log: {log.Level}");
                    Console.WriteLine($"Log: {log.Source}");
                    Console.WriteLine($"Log: {log.Message}");
                }
        }
        else
        {
            Console.WriteLine("Please enter valid message text: ");
        }
    }
    else
    {
        Console.WriteLine("Invalid filter choice: ");
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
    bool reportSaved = service.SaveReport("report.txt");
    if (reportSaved == true)
    {
        Console.WriteLine("Report saved to report.txt!");
    }
    else 
    {
        Console.WriteLine("Report failed to save");
    }
} 
else if (choice == "5")
    {
        List<LogEntry> sortedLogs = service.GetSortedBySource();
        foreach (LogEntry log in sortedLogs)
        {
            Console.WriteLine($"Log: {log.Level} | {log.Source} | {log.Message}"); 
        }
    }
else if (choice == "6")
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