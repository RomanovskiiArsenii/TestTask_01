using TestTask_01.Convertation;
using TestTask_01.Reading;
using TestTask_01.Writing;
namespace TestTask_01;

class TestTask
{
    static void Main()
    {
        //Tested sequence:
        //1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420

        IConvertArrayViaRule<string, int, Dictionary<int, string>> converter = new CompareAndConvertIntegersToString();
        IConvertArrayViaRule<string, int, Dictionary<int, string>> converterWithReplace = new CompareAndConvertIntegersToStringAndReplaceMatches(
                                                          "good-boy", new List<string> () { "dog", "cat" });
        IReadToArray<int> reader = new ReadIntegersFromConsole();

        IWriteCollection<int> writerInt = new WriteCollectionToConsole<int> ();
        IWriteCollection<string> writerStr = new WriteCollectionToConsole<string> ();

        int[] range = reader.ReadToArray().ToArray();
        Console.WriteLine("Control sequence:");
        writerInt.WriteCollection(range);
        Console.WriteLine();

        Dictionary<int, string> firstConversion = new()
        {
            { 3, "fizz" },
            { 5, "buzz" }
        };
        var resultOfFirstConvertion = converter.ConvertArray(range, firstConversion);
        writerStr.WriteCollection(resultOfFirstConvertion);
        Console.WriteLine("Control sequence:\n1, 2, fizz, 4, buzz, fizz, 7, 8, fizz, " +
            "buzz, 11, fizz, 13, 14, fizz-buzz, fizz-buzz, fizz-buzz, fizz-buzz\n");


        Dictionary<int, string> secondConversion = new()
        {
            { 3, "fizz" },
            { 5, "buzz" },
            { 4, "muzz" },
            { 7, "guzz" }
        };
        var resultOfSecondConvertion = converter.ConvertArray(range, secondConversion);
        writerStr.WriteCollection(resultOfSecondConvertion);
        Console.WriteLine("Control sequence:\n1, 2, fizz, muzz, buzz, fizz, guzz, muzz, " +
            "fizz, buzz, 11, fizz-muzz, 13, guzz, fizz-buzz, fizz-buzz-muzz, fizz-buzz-guzz, " +
            "fizz-buzz-muzz-guzz\n");

        Dictionary<int, string> thirdConversion = new()
        {
            { 3, "dog" },
            { 4, "muzz" },
            { 5, "cat" },
            { 7, "guzz" }
        };
        var resultOfThirdConvertion = converterWithReplace.ConvertArray(range, thirdConversion);
        writerStr.WriteCollection(resultOfThirdConvertion);
        Console.WriteLine("Control sequence:\n1, 2, dog, muzz, cat, dog, guzz, muzz, dog, cat, 11, " +
            "dog-muzz, 13, guzz, good-boy, good-boy-muzz, good-boy-guzz, good-boy-muzz-guzz");
    }
}