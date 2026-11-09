public class LogService
{
private List<LogEntry> logs = new List<LogEntry>();

public void Add(LogEntry entry)
    {
        logs.Add(entry);
    }

public List<LogEntry> GetAll()
    {
        return new List<LogEntry>(logs);
    }

public List<LogEntry> GetByLevel(string level)
    {
         return logs
        .Where(log => log.Level.Equals(level, StringComparison.OrdinalIgnoreCase))
        .ToList();
    }

public List<LogEntry> GetBySource(string source)
    {
        return logs
        .Where(log => log.Source.Equals(source, StringComparison.OrdinalIgnoreCase))
        .ToList();
    }

public List<LogEntry> SearchByMessage(string text)
    {
        return logs
        .Where(log => log.Message.Contains(text, StringComparison.OrdinalIgnoreCase))
        .ToList();
    }

public List<LogEntry> GetSortedBySource()
    {
        return logs
        .OrderBy(log => log.Source)
        .ToList();
    }

public int GetTotalCount()
    {
        return logs.Count;
    }

public int GetErrorCount()
    {
        return
        logs.Count(log => log.Level.Equals("ERROR", StringComparison.OrdinalIgnoreCase));
    }

public int GetCountByLevel(string level)
    {
        return
        logs.Count(log => log.Level.Equals(level, StringComparison.OrdinalIgnoreCase));
    }

public bool HasErrors()
    {
        return
        logs.Any(log => log.Level.Equals("ERROR", StringComparison.OrdinalIgnoreCase));
    }

public void LoadFromFile(string filePath)
    {   
            if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found");
            return;
        }
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            if (parts.Length == 3 
            && !string.IsNullOrWhiteSpace(parts[0])
            && !string.IsNullOrWhiteSpace(parts[1]) 
            && !string.IsNullOrWhiteSpace(parts[2])
            && (parts[0].Equals("INFO", StringComparison.OrdinalIgnoreCase)
            || parts[0].Equals("WARNING", StringComparison.OrdinalIgnoreCase)
            || parts[0].Equals("ERROR", StringComparison.OrdinalIgnoreCase)))
            {
                LogEntry entry = new LogEntry(parts[0], parts[1], parts[2]);
                logs.Add(entry);
            }
                else
            {
                Console.WriteLine("Invalid log data, line skipped");
            }
        }
    }  
public void SaveReport(string filePath)
    {
        string report = "Log Analysis Report";
        report += $"\nTotal logs: {GetTotalCount()}";
        report += $"\nInfo logs: {GetCountByLevel("INFO")}";
        report += $"\nError logs: {GetCountByLevel("ERROR")}";
        report += $"\nWarning logs: {GetCountByLevel("WARNING")}";
        report += $"\nContains errors: {HasErrors()}";
        File.WriteAllText(filePath, report);
    }
}