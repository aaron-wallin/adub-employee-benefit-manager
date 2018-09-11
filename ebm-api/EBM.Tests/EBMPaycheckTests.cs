using EBM.BenefitLogic;
using EBM.BenefitLogic.BenefitPolicies;
using EBM.Entities.Factories;
using EBM.PaycheckLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EBM.Tests
{
    [TestClass]
    public class EBMPaycheckTests
    {
        [TestMethod]
        public void EmployeeOnlyNoDiscount()
        {
            var emp = new EmployeeFactory().CreateEmployee(52000, 26);
            emp.FirstName = "John";

            var b = new BenefitCalculatorService(new NameDiscountPolicy());
            var p = new PaycheckCalculatorService(b);

            p.Calculate(emp);

            Assert.AreEqual(emp.PayCheck.GrossAmount, 2000);
            Assert.AreEqual(emp.PayCheck.NetAmount, 1961.54M);
            Assert.AreEqual(emp.PayCheck.Deductions.Count, 1);
            Assert.AreEqual(emp.PayCheck.Deductions["Benefits"], 38.46M);
        }

        [TestMethod]
        public void EmployeeOnlyWithDiscount()
        {
            var emp = new EmployeeFactory().CreateEmployee(52000, 26);
            emp.FirstName = "Aaron";

            var b = new BenefitCalculatorService(new NameDiscountPolicy());
            var p = new PaycheckCalculatorService(b);

            p.Calculate(emp);

            Assert.AreEqual(emp.PayCheck.GrossAmount, 2000);
            Assert.AreEqual(emp.PayCheck.NetAmount, 1965.38M);
            Assert.AreEqual(emp.PayCheck.Deductions.Count, 1);
            Assert.AreEqual(emp.PayCheck.Deductions["Benefits"], 34.62M);
        }

        [TestMethod]
        public void EmployeeWithDependentNoDiscount()
        {
            var emp = new EmployeeFactory().CreateEmployee(52000, 26);
            emp.FirstName = "John";

            emp.Dependents.Add(new DependentFactory().CreateDependent("Jane", "Smith"));

            var b = new BenefitCalculatorService(new NameDiscountPolicy());
            var p = new PaycheckCalculatorService(b);

            p.Calculate(emp);

            Assert.AreEqual(emp.PayCheck.GrossAmount, 2000);
            Assert.AreEqual(emp.PayCheck.NetAmount, 1942.31M);
            Assert.AreEqual(emp.PayCheck.Deductions.Count, 1);
            Assert.AreEqual(emp.PayCheck.Deductions["Benefits"], 57.69M);
        }

        [TestMethod]
        public void EmployeeWithDependentWithDiscount()
        {
            var emp = new EmployeeFactory().CreateEmployee(52000, 26);
            emp.FirstName = "Aaron";

            emp.Dependents.Add(new DependentFactory().CreateDependent("Allison", "Smith"));

            var b = new BenefitCalculatorService(new NameDiscountPolicy());
            var p = new PaycheckCalculatorService(b);

            p.Calculate(emp);

            Assert.AreEqual(emp.PayCheck.GrossAmount, 2000);
            Assert.AreEqual(emp.PayCheck.NetAmount, 1948.08M);
            Assert.AreEqual(emp.PayCheck.Deductions.Count, 1);
            Assert.AreEqual(emp.PayCheck.Deductions["Benefits"], 51.92M);
        }
    }
}
