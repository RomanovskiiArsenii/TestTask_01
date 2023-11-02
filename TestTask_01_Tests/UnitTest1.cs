using TestTask_01.Convertation;
namespace TestTask_01_Tests;

public class Tests
{
    CompareAndConvertIntegersToString converter = new();
    int[] range = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 };
    int[] smallerRange = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

    [Test]
    public void ConvertArray_FizzBuzz_ReturnsCorrectString()
    {
        string controlSequence = "1, 2, fizz, 4, buzz, fizz, 7, 8, fizz, buzz, 11, fizz, 13, 14, fizz-buzz";
        Dictionary<int, string> Conversion = new()
        {
            { 3, "fizz" },
            { 5, "buzz" }
        };
        string output = convertAndJoin(converter, Conversion, smallerRange);
        Assert.That(controlSequence == output);
    }

    [Test]
    public void ConvertArray_FizzBuzzMuzzGuzz_ReturnsCorrectString()
    {
        string controlSequence = "1, 2, fizz, muzz, buzz, fizz, guzz, muzz, fizz, buzz, 11, fizz-muzz, 13, guzz, fizz-buzz, fizz-buzz-muzz, fizz-buzz-guzz, fizz-buzz-muzz-guzz";
        Dictionary<int, string> Conversion = new()
        {
            { 3, "fizz" },
            { 5, "buzz" },
            { 4, "muzz" },
            { 7, "guzz" }
        };
        string output = convertAndJoin(converter, Conversion, range);
        Assert.That(controlSequence == output);
    }

    [Test]
    public void ConvertArray_DogCatGoodBoyMuzzGuzz_ReturnsCorrectString()
    {
        ConvertIntArrToStringArrAndReplaceMatches converterWithReplace = new("good-boy", new List<string>() { "dog", "cat" });
        string controlSequence = "1, 2, dog, muzz, cat, dog, guzz, muzz, dog, cat, 11, dog-muzz, 13, guzz, good-boy, good-boy-muzz, good-boy-guzz, good-boy-muzz-guzz";
        Dictionary<int, string> Conversion = new()
        {
            { 3, "dog" },
            { 4, "muzz" },
            { 5, "cat" },
            { 7, "guzz" }
        };
        string output = convertAndJoin(converterWithReplace, Conversion, range);
        Assert.That(controlSequence == output);
    }

    public string convertAndJoin(CompareAndConvertIntegersToString converter, Dictionary<int, string> Conversion, int[] range)
    {
        var resultOfConvertion = converter.ConvertArray(range, Conversion);
        return (string.Join(", ", resultOfConvertion));
    }
}
