namespace TestTask_01.Convertation;

/// <summary>
/// Provides convertation of an collection according to rules
/// </summary>
/// <typeparam name="TOut">converted collection type</typeparam>
/// <typeparam name="TIn">input collection type</typeparam>
/// <typeparam name="TRule">custom rules arguments</typeparam>
internal interface IConvertArrayViaRule<TOut, TIn, TRule>
{
    /// <summary>
    /// Convertation of an array according to rules
    /// </summary>
    /// <param name="collection">input collection</param>
    /// <param name="rules">custom rules arguments</param>
    /// <returns>converted collection</returns>
    IEnumerable<TOut> ConvertArray(IEnumerable<TIn> collection, TRule rules);
}
