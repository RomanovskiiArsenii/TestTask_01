namespace TestTask_01.Convertation;

/// <summary>
/// Provides comparing and convertation of an int collection to the string collection according to rules
/// </summary>
public class CompareAndConvertIntegersToString : IConvertArrayViaRule<string, int, Dictionary<int, string>>
{
    /// <summary>
    /// Comparing and converting int collection to string collection according to rules:
    /// if element divides by key without a reminder it converts to string and collect key's value
    /// otherwise element simply converts to string
    /// </summary>
    /// <param name="collection">input int collection</param>
    /// <param name="rules">rules arguments</param>
    /// <returns>converted string collection</returns>
    public virtual IEnumerable<string> ConvertArray(IEnumerable<int> collection, Dictionary<int, string> rules)
    {
        List<string> converted = new();                                     //resulting List
        foreach (var item in collection)                                         
        {
            List<string> matches = new();                                   //the List is used to collect values into a string
            foreach (var kvp in rules)                                      //comparison with each key-value pair
            {
                if (kvp.Key != 0)                                           //check for divide by zero
                {
                    if (item % kvp.Key == 0) matches.Add(kvp.Value);        //if there is no remainder after division by the key, collect the value
                }
            }
            if (matches.Any()) converted.Add(string.Join("-", matches));    //if there are values collected in the list element, replace the number with the list element
            else converted.Add(item.ToString());                            //otherwise, leave the original number
        }
        return converted;
    }
}
