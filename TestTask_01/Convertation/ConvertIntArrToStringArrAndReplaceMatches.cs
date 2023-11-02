namespace TestTask_01.Convertation;
/// <summary>
/// Provides comparing and convertation of an int collection to the string collection according to rules
/// Additionally removing collection of values and inserting value
/// </summary>
internal class ConvertIntArrToStringArrAndReplaceMatches : CompareAndConvertIntegersToString
{
    private readonly string _replacement;                   //value to be added
    private readonly IEnumerable<string> _removing;         //collection of values to be deleted
    public ConvertIntArrToStringArrAndReplaceMatches(string replacement, IEnumerable<string> removing)
    {
        _replacement = replacement; _removing = removing;
    }

    /// <summary>
    /// Comparing and converting int collection to string collection according to rules:
    /// if element divides by key without a reminder it converts to string and collect key's value
    /// otherwise element simply converts to string
    /// if the converted element contains all of elements from "removing" collection, they will be 
    /// removed from converted element, "replacement" value will be inserted in the beginning of element
    /// </summary>
    /// <param name="collection">input int collection</param>
    /// <param name="rules">rules arguments</param>
    /// <returns>converted string collection</returns>
    public override IEnumerable<string> ConvertArray(IEnumerable<int> collection, Dictionary<int, string> rules)
    {
        List<string> converted = new();                                         //resulting List
        foreach (var item in collection)
        {
            List<string> matches = new();                                       //the List is used to collect values into a string
            bool flag = true;                                                   //flag defines if there are all of the values from the removing list contain in string
            foreach (var kvp in rules)                                          //comparison with each key-value pair
            {
                if (kvp.Key != 0)                                               //check for divide by zero
                {
                    if (item % kvp.Key == 0) matches.Add(kvp.Value);            //if there is no remainder after division by the key, collect the value to string
                }
            }
            foreach (var r in _removing) 
                if (!matches.Contains(r)) { flag = false; break; }              //if there is one element from removing list that string doesn't contain then false
            
            if (flag)                                                           //true if there are all of them instead
            {
                foreach (var r in _removing) matches.Remove(r);                 //remove them from the string            
                matches.Insert(0, _replacement);                                //insert value to the begin of string
            }
            if (matches.Any()) converted.Add(string.Join("-", matches));        //if there are values collected in the list element, replace the number with the list element
            else converted.Add(item.ToString());                                //otherwise, leave the original number
        }
        return converted;
    }
}
