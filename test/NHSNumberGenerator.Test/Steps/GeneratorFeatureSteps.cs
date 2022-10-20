using NHSNumberValidator;
using Shouldly;

namespace NHSNumberGenerator.Test.Steps;

[Binding]
public class GeneratorFeatureSteps
{
    private readonly List<string> _generated = new();

    [Given(@"A single NHS Number")]
    public void GivenASingleNhsNumber()
    {
        _generated.Add(Generator.Generate());
    }

    [Then(@"NHS Number should be valid")]
    public void ThenNhsNumberShouldBeValid()
    {
        ValidateNhsNumber(_generated.First());
    }

    private static void ValidateNhsNumber(string nhsNumber)
    {
        nhsNumber.ShouldSatisfyAllConditions(
            g => Validator.Validate(g).ShouldBeTrue()
        );
    }

    [Given(@"Two different NHS Numbers are generated")]
    public void GivenTwoDifferentNhsNumbersAreGenerated()
    {
        _generated.Add(Generator.Generate());
        _generated.Add(Generator.Generate());
    }

    [Then(@"NHS Numbers should be valid")]
    public void ThenNhsNumbersShouldBeValid()
    {
        _generated.ForEach(ValidateNhsNumber);
    }

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
}