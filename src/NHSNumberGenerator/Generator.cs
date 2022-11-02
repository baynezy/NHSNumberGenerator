using System.Text;

namespace NHSNumberGenerator;

public static class Generator
{
    /// <summary>
    /// Generates a random NHS number in a valid format
    /// </summary>
    /// <returns>A random NHS number in a valid format</returns>
    public static string Generate()
    {
        var number = new NhsNumber();
        return number.Calculate();
    }

    private class NhsNumber
    {

        private readonly Random _random = new();
        private const int NhsNumberSegments = 9;
        private List<NumberPart> _numberParts = null!;
        private readonly int[] _weightings = {10,9,8,7,6,5,4,3,2};


        internal NhsNumber()
        {
            InitialiseParts();
        }

        private void InitialiseParts()
        {
            _numberParts = new List<NumberPart>();
            for (var position = 0; position < NhsNumberSegments; position++)
            {
                _numberParts.Add(new NumberPart
                {
                    Number = RandomDigit(),
                    Factor = GetPositionFactor(position)
                });
            }
        }

        private int GetPositionFactor(int position)
        {
            return _weightings[position];
        }

        private int RandomDigit()
        {
            return _random.Next(0, 10);
        }

        private class NumberPart
        {
            internal int Number { get; init; }
            internal int Factor { get; init; }
        }

        internal string Calculate()
        {
            var total = _numberParts.Sum(part => part.Number * part.Factor);
            var remainder = total % 11;
            
            var checkDigit = (remainder == 0) ? 0 : 11 - remainder;
            if (checkDigit == 10) // 10 is not a valid check digit. So must regenerate
            {
                InitialiseParts();
                // ReSharper disable once TailRecursiveCall
                return Calculate();
            }
            
            _numberParts.Add(new NumberPart
            {
                Number = checkDigit,
                Factor = 1
            });
            
            var calculatedNhsNumber = new StringBuilder();
            foreach (var numberPart in _numberParts)
            {
                calculatedNhsNumber.Append(numberPart.Number);
            }
            
            return calculatedNhsNumber.ToString();
        }
    }
}