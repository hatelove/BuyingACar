using BuyingACar;
using NUnit.Framework;
using NUnit.Framework.Internal;
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

    [Test]
    public void nbMonths_old_7000_new_8000_perMonthSave_1000_percentLoss_1point5()
    {
        //old one after 1 month: 6895
        //saving amount after 1 month: 1000
        //new one after 1 month: 7880

        int[] r = new int[] { 1, 15 };
        Assert.AreEqual(r, BuyCar.nbMonths(7000, 8000, 1000, 1.5f));
    }

    [Test]
    public void nbMonths_old_7000_new_8000_perMonthSave_985_percentLoss_1point5()
    {
        int[] r = new int[] { 1, 0 };
        Assert.AreEqual(r, BuyCar.nbMonths(7000, 8000, 985, 1.5f));
    }

    [Ignore("one and only one red light")]
    [Test]
    public void nbMonths_old_2000_new_8000_perMonthSave_1000_percentLoss_1point5()
    {
        int[] r = new int[] { 6, 766 };
        //{ 0.985 , 0.98 , 0.98 , 0.975 , 0.975 , 0.97 }
        //new one after 6 month: 6978.4558389
        //old one after 6 month: 1744.613959725

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
            double leftOverMoney = 0;
            double oldOneValue = startPriceOld;
            double newOneValue = startPriceNew;
            var savingAmount = 0;

            if (startPriceOld >= startPriceNew)
            {
                leftOverMoney = startPriceOld - startPriceNew;
            }
            else
            {
                do
                {
                    month++;
                    savingAmount += savingperMonth;
                    if (month % 2 != 0)
                    {
                        oldOneValue *= 1 - (percentLossByMonth / 100);
                        newOneValue *= 1 - (percentLossByMonth / 100);
                        leftOverMoney = oldOneValue - newOneValue + savingAmount;
                    }
                } while (leftOverMoney < 0);
            }

            return new int[] { month, (int)Math.Round(leftOverMoney, 0) };
        }
    }
}