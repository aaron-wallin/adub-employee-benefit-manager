using EBM.Models;
using EBM.Models.BenefitDiscount;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace EBM.Tests
{
    [TestClass]
    public class EBMTestClass
    {
        [TestMethod]
        public void EmployeeOnlyWithNoName()
        {
            var emp = new Employee();
            var benCalc = new BenefitCalculatorService(new NameDiscountPolicy());

            var results = benCalc.Calculate(emp);

            Assert.AreEqual(results.BaseAnnualCost, 1000);
            Assert.AreEqual(results.DiscountApplied, false);
            Assert.AreEqual(results.DiscountedAnnualCost, 1000);
            Assert.AreEqual(results.PerPayPeriodCost, 38.46M);
        }

        [TestMethod]
        public void EmployeeOnlyWithNameDiscount()
        {
            var emp = new Employee() { FirstName = "Aaron" };
            var benCalc = new BenefitCalculatorService(new NameDiscountPolicy());

            var results = benCalc.Calculate(emp);

            Assert.AreEqual(results.BaseAnnualCost, 1000);
            Assert.AreEqual(results.DiscountApplied, true);
            Assert.AreEqual(results.DiscountedAnnualCost, 900);
            Assert.AreEqual(results.PerPayPeriodCost, 34.62M);
        }

        [TestMethod]
        public void EmployeeWithDependentsNoDiscount()
        {
            var emp = new Employee() { FirstName = "John" };
            emp.Dependents.Add(new Dependent() { FirstName = "Jane" });
            var benCalc = new BenefitCalculatorService(new NameDiscountPolicy());

            var results = benCalc.Calculate(emp);

            Assert.AreEqual(results.BaseAnnualCost, 1500);
            Assert.AreEqual(results.DiscountApplied, false);
            Assert.AreEqual(results.DiscountedAnnualCost, 1500);
            Assert.AreEqual(results.PerPayPeriodCost, 57.69M);
        }

        [TestMethod]
        public void EmployeeWithDependentsWithDiscount()
        {
            var emp = new Employee() { FirstName = "John" };
            emp.Dependents.Add(new Dependent() { FirstName = "Aaron" });
            var benCalc = new BenefitCalculatorService(new NameDiscountPolicy());

            var results = benCalc.Calculate(emp);

            Assert.AreEqual(results.BaseAnnualCost, 1500);
            Assert.AreEqual(results.DiscountApplied, true);
            Assert.AreEqual(results.DiscountedAnnualCost, 1450);
            Assert.AreEqual(results.PerPayPeriodCost, 55.77M);
            Assert.AreEqual(results.PerPayPeriodCost, emp.Benefits.PerPayPeriodCost + emp.Dependents.Sum(_ => _.Benefits.PerPayPeriodCost));
        }

        [TestMethod]
        public void EmployeeWithMultipleDependentsAllWithDiscount()
        {
            var emp = new Employee() { FirstName = "Adrienne" };
            emp.Dependents.Add(new Dependent() { FirstName = "Aaron" });
            emp.Dependents.Add(new Dependent() { FirstName = "Andrew" });
            emp.Dependents.Add(new Dependent() { FirstName = "Arnold" });
            var benCalc = new BenefitCalculatorService(new NameDiscountPolicy());

            var results = benCalc.Calculate(emp);

            Assert.AreEqual(results.BaseAnnualCost, 2500);
            Assert.AreEqual(results.DiscountApplied, true);
            Assert.AreEqual(results.DiscountedAnnualCost, 2250);
            Assert.AreEqual(results.PerPayPeriodCost, 55.77M);
            Assert.AreEqual(results.PerPayPeriodCost, emp.Benefits.PerPayPeriodCost + emp.Dependents.Sum(_ => _.Benefits.PerPayPeriodCost));
        }
    }
}
