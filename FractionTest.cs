using Fractions.Models;

namespace Fractions;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void ShouldAddIntegerFractions()
    {
        var fraction = new Fraction(1);

        Assert.AreEqual("3", fraction.Add(new Fraction(2)).ToString());
    }

    [TestMethod]
    public void ShouldAddFractionsWithCommonDenominator()
    {
        var fraction = new Fraction(1, 3);

        Assert.AreEqual("2/3", fraction.Add(new Fraction(1, 3)).ToString());
    }

    [TestMethod]
    public void ShouldAddFractionsWithDifferentDenominator()
    {
        var fraction = new Fraction(1, 3);

        Assert.AreEqual("8/15", fraction.Add(new Fraction(1, 5)).ToString());
    }

    [TestMethod]
    public void ShouldReturnTheLowestPossibleFraction()
    {
        var fraction = new Fraction(5, 13);

        Assert.AreEqual("10/13", fraction.Add(new Fraction(10, 26)).ToString());
    }
}