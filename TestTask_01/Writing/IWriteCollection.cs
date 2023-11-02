namespace TestTask_01.Writing;

/// <summary>
/// Provides writing of a collection
/// </summary>
/// <typeparam name="T">input collection's element type</typeparam>
internal interface IWriteCollection<T>
{
    /// <summary>
    /// Writing every element of an array
    /// </summary>
    /// <param name="collection">input collection</param>
    void WriteCollection(IEnumerable<T> collection);
}

