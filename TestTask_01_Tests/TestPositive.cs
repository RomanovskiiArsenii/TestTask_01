using TestTask_01.Convertation;
namespace TestTask_01_Tests;

public class Tests
{
    private readonly CompareAndConvertIntegersToString _converter = new();
    private readonly int[] _range = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420 };
    private readonly int[] _smallerRange = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

    [Test]
    public void ConvertArray_FizzBuzz_ReturnsCorrectString()
    {
        var controlSequence = "1, 2, fizz, 4, buzz, fizz, 7, 8, fizz, buzz, 11, fizz, 13, 14, fizz-buzz";
        Dictionary<int, string> conversion = new()
        {
            { 3, "fizz" },
            { 5, "buzz" }
        };
        if (conversion == null) throw new ArgumentNullException(nameof(conversion));
        var output = ConvertAndJoin(_converter, conversion, _smallerRange);
        Assert.That(controlSequence, Is.EqualTo(output));
    }

    [Test]
    public void ConvertArray_FizzBuzzMuzzGuzz_ReturnsCorrectString()
    {
        var controlSequence = "1, 2, fizz, muzz, buzz, fizz, guzz, muzz, fizz, buzz, 11, fizz-muzz, 13, guzz, fizz-buzz, fizz-buzz-muzz, fizz-buzz-guzz, fizz-buzz-muzz-guzz";
        Dictionary<int, string> conversion = new()
        {
            { 3, "fizz" },
            { 5, "buzz" },
            { 4, "muzz" },
            { 7, "guzz" }
        };
        var output = ConvertAndJoin(_converter, conversion, _range);
        Assert.That(controlSequence, Is.EqualTo(output));
    }

    [Test]
    public void ConvertArray_DogCatGoodBoyMuzzGuzz_ReturnsCorrectString()
    {
        CompareAndConvertIntegersToStringAndReplaceMatches converterWithReplace = new("good-boy", new List<string> { "dog", "cat" });
        var controlSequence = "1, 2, dog, muzz, cat, dog, guzz, muzz, dog, cat, 11, dog-muzz, 13, guzz, good-boy, good-boy-muzz, good-boy-guzz, good-boy-muzz-guzz";
        Dictionary<int, string> conversion = new()
        {
            { 3, "dog" },
            { 4, "muzz" },
            { 5, "cat" },
            { 7, "guzz" }
        };
        var output = ConvertAndJoin(converterWithReplace, conversion, _range);
        Assert.That(controlSequence, Is.EqualTo(output));
    }

    private static string ConvertAndJoin(CompareAndConvertIntegersToString converter, Dictionary<int, string> conversion, int[] range)
    {
        var resultOfConvertion = converter.ConvertArray(range, conversion);
        return string.Join(", ", resultOfConvertion);
    }
}