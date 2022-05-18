using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace TDD1.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void BubbleSortTest()
        {
            Form1 form1 = new Form1();
            Form1.Employees = form1.getTenThousand();
            form1.BubbleSort();
            Assert.AreEqual(10000, Form1.Employees.Count); //Check if the list of workers lost a value during the sort
            Assert.IsNotNull(Form1.Employees); //Checks if the list isn't null.
            Assert.IsTrue(form1.sortCheck()); //Checks if the list is indeed sorted.
            Assert.AreNotEqual(9999, Form1.Employees.Count); //Check if the list of workers lost a value during the sort
        }

        
        [TestMethod()]
        public void CalcTaxTest()
        {
           Form1 form1 = new Form1();
           double salary_1 = 15000;
           double f1 = form1.CalcTax(salary_1);
           salary_1 = (salary_1 * 31) / 100; //Chose correct tax rate to get equal result.
           Assert.AreEqual(salary_1, f1);


           double salary_2 = 10000;
           double f2 = form1.CalcTax(salary_2);
           salary_2 = (salary_2 * 22) / 100; //Chose wrong tax rate to get unequal result.
           Assert.AreNotEqual(salary_2, f2);
        }
        
        [TestMethod()]
        public void QuickSortTest()
        {
            Form1 form1 = new Form1();
            Form1.Employees = form1.getTenThousand();
            form1.QuickSort(Form1.Employees, 0, Form1.Employees.Count - 1);

            Assert.AreEqual(10000, Form1.Employees.Count); //Check if the list of workers lost a value during the sort
            Assert.IsNotNull(Form1.Employees); //Checks if the list isn't null.
            Assert.IsTrue(form1.sortCheck()); //Checks if the list is indeed sorted.
            Assert.AreNotEqual(9999, Form1.Employees.Count); //Check if the list of workers lost a value during the sort
 

        }
    }
}