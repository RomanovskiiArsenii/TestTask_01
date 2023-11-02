namespace TestTask_01.Reading;

/// <summary>
/// Provides reading from an input source to the collection
/// </summary>
/// <typeparam name="T">output collection's element type</typeparam>
internal interface IReadToArray<T>
{
    /// <summary>
    /// Reading from an input source to the collection
    /// </summary>
    /// <returns>output collection</returns>
    IEnumerable<T> ReadToArray();
}
