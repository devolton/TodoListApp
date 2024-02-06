using System.Text.RegularExpressions;

namespace TodoList;
public static class TaskValidator
{
    private static readonly Regex _taskregex;
    
    static TaskValidator()
    {
        _taskregex = new Regex("^[\\wа-яА-Я\\d\\s()-_@!?]{6,64}$");
    }
    public static bool IsValidTask(string task) => _taskregex.IsMatch(task);
    public static bool IsValidDeadlineDate(DateTime deadline) => deadline > DateTime.Now;

}

