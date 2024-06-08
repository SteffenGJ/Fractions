namespace Fractions.Models;

public class Fraction(int numerator, int denominator = 1)
{

    private int _numerator = numerator;
    private int _denominator = denominator;

    public Fraction Add(Fraction fraction)
    {
        if (fraction.IsCommonDenominator(_denominator))
        {
            var result = fraction.AddNumerator(_numerator);
            result.ToLowestDenominator();
            return result;
        }
        else
        {
            var result = fraction.FindCommonDenominatorFraction(_numerator, _denominator);
            result.ToLowestDenominator();
            return result;
        }
    }

    public override string ToString()
    {
        if (IsWholeNumber())
        {
            return _numerator.ToString();
        }
        else
        {
            return _numerator.ToString() + "/" + _denominator.ToString();
        }
    }

    public bool IsCommonDenominator(int denominator)
    {
        return _denominator == denominator;
    }

    public bool IsWholeNumber()
    {
        return _denominator == 1;
    }

    public Fraction FindCommonDenominatorFraction(int numerator, int denominator)
    {
        var commonDenominator = _denominator * denominator;
        var newNumerator = _numerator * denominator + numerator * _denominator;
        return new Fraction(newNumerator, commonDenominator);
    }

    public Fraction AddNumerator(int numerator)
    {
        return new Fraction(_numerator + numerator, _denominator);
    }

    public void ToLowestDenominator()
    {
        if (!IsWholeNumber())
        {
            int gcd = CalculateGCD(_numerator, _denominator);
            _denominator /= gcd;
            _numerator /= gcd;
        }
    }

    private int CalculateGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}