using BuyingACar;
using NUnit.Framework;
using System;

[TestFixture]
public class BuyCarTests
{
    [Test]
    public void nbMonths_old_12000_new_8000_perMonthSave_1000_percentLoss_1point5()
    {
        int[] r = new int[] { 0, 4000 };
        Assert.AreEqual(r, BuyCar.nbMonths(12000, 8000, 1000, 1.5f));
    }

    [Ignore("one and only one red light")]
    [Test]
    public void nbMonths_old_2000_new_8000_perMonthSave_1000_percentLoss_1point5()
    {
        int[] r = new int[] { 6, 766 };
        Assert.AreEqual(r, BuyCar.nbMonths(2000, 8000, 1000, 1.5f));
    }
}

namespace BuyingACar
{
    internal class BuyCar
    {
        public static int[] nbMonths(int startPriceOld, int startPriceNew, int savingperMonth, float percentLossByMonth)
        {
            var month = 0;
            var leftOverMoney = 0;
            if (startPriceOld >= startPriceNew)
            {
                leftOverMoney = startPriceOld - startPriceNew;
            }

            return new int[] {month, leftOverMoney};
        }
    }
}