using NHSNumberValidator;
using Shouldly;

namespace NHSNumberGenerator.Test.Steps;

[Binding]
public class GeneratorFeatureSteps
{
    private readonly List<string> _generated = new();

    [Given(@"A single NHS Number")]
    public void GivenASingleNhsNumber() => GivenNhsNumbers(1);

    [Then(@"NHS Number should be valid")]
    public void ThenNhsNumberShouldBeValid() => ValidateNhsNumber(_generated.First());

    private static void ValidateNhsNumber(string nhsNumber)
    {
        nhsNumber.ShouldSatisfyAllConditions(
            g => Validator.Validate(g).ShouldBeTrue()
        );
    }

    [Given(@"Two different NHS Numbers are generated")]
    public void GivenTwoDifferentNhsNumbersAreGenerated() => GivenNhsNumbers(2);

    [Then(@"NHS Numbers should be valid")]
    public void ThenNhsNumbersShouldBeValid() => _generated.ForEach(ValidateNhsNumber);

    [Then(@"NHS Numbers should be different")]
    public void ThenNhsNumbersShouldBeDifferent()
    {
        var duplicateChecker = new Dictionary<string, bool>();
        
        _generated.ForEach(nhsNumber =>
        {
            if (duplicateChecker.ContainsKey(nhsNumber))
            {
                throw new Exception($"Duplicate NHS Number found: {nhsNumber}");
            }

            duplicateChecker.Add(nhsNumber, true);
        });
    }

    [Given(@"(.*) NHS Number\(s\)")]
    public void GivenNhsNumbers(int howMany)
    {
        for (var i = 0; i < howMany; i++)
        {
            _generated.Add(Generator.Generate());
        }
    }
}