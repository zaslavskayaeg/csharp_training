using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace address_book_web_tests.tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double total = 999;
            bool vipClient = true;

            if (total > 1000 || vipClient)
            {
                total = total * 0.9;
                System.Console.Out.Write("Скидка 10%, общая сумма " + total);
            }
          /*  else
            {
                --System.Console.Out.Write("Скидки нет, общая сумма " + total);
            }*/
            
        }
    }
}
