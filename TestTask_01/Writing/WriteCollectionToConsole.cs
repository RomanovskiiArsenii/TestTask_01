namespace TestTask_01.Writing;

/// <summary>
/// Provides the method for writing collection to the console
/// </summary>
/// <typeparam name="T">input collection's element type</typeparam>
internal class WriteCollectionToConsole<T> : IWriteCollection<T>
{
    /// <summary>
    /// Separates the collection and writes it to the console
    /// </summary>
    public void WriteCollection(IEnumerable<T> collection)
    {
        string output = string.Join(", ", collection);          //separate the collection and convert it to string
        Console.WriteLine(output);                              //print it in console
    }
}
