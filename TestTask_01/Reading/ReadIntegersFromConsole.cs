using System.Text.RegularExpressions;
namespace TestTask_01.Reading;

/// <summary>
/// Provides reading integers from the console and store them in the int collection
/// </summary>
internal class ReadIntegersFromConsole : IReadToArray<int>
{
    /// <summary>
    /// Reading input from the console and placing integers into the int collection
    /// </summary>
    /// <returns>int collection</returns>
    public IEnumerable<int> ReadToArray()
    {
        string? input = Console.ReadLine();                                     //reading from the console to the nullable string
        if (input == null) return Array.Empty<int>();                           //verification (e.g. [Ctrl+Z + Enter] returns null)
        MatchCollection matches = Regex.Matches(input, @"\d+");                 //separating the integers out of the input string
        return matches.Select(m => int.Parse(m.Value));                         //placing the integers in the collection                                  
    }
}
