using EBM.BenefitLogic;
using EBM.BenefitLogic.BenefitPolicies;
using EBM.Entities.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EBM.Tests
{
    [TestClass]
    public class EBMBenefitTests
    {   
        [TestMethod]
        public void EmployeeOnlyWithNoName()
        {
            var emp = new EmployeeFactory().CreateEmployee(52000, 26);
            var benCalc = new BenefitCalculatorService(new NameDiscountPolicy());

            var results = benCalc.Calculate(emp);

            Assert.AreEqual(results.BaseAnnualCost, 1000);
            Assert.AreEqual(results.DiscountApplied, false);
            Assert.AreEqual(results.DiscountedAnnualCost, 1000);
        }

        [TestMethod]
        public void EmployeeOnlyWithNameDiscount()
        {
            var emp = new EmployeeFactory().CreateEmployee(52000, 26);
            emp.FirstName = "Aaron";

            var benCalc = new BenefitCalculatorService(new NameDiscountPolicy());

            var results = benCalc.Calculate(emp);

            Assert.AreEqual(results.BaseAnnualCost, 1000);
            Assert.AreEqual(results.DiscountApplied, true);
            Assert.AreEqual(results.DiscountedAnnualCost, 900);
        }

        [TestMethod]
        public void EmployeeWithDependentsNoDiscount()
        {
            var emp = new EmployeeFactory().CreateEmployee(52000, 26);
            emp.FirstName = "John";

            emp.Dependents.Add(new DependentFactory().CreateDependent("Jane", "Doe"));

            var benCalc = new BenefitCalculatorService(new NameDiscountPolicy());
            var results = benCalc.Calculate(emp);

            Assert.AreEqual(results.BaseAnnualCost, 1500);
            Assert.AreEqual(results.DiscountApplied, false);
            Assert.AreEqual(results.DiscountedAnnualCost, 1500);
        }

        [TestMethod]
        public void EmployeeWithDependentsWithDiscount()
        {
            var emp = new EmployeeFactory().CreateEmployee(52000, 26);
            emp.FirstName = "John";
            emp.Dependents.Add(new DependentFactory().CreateDependent("Aaron", "Doe"));

            var benCalc = new BenefitCalculatorService(new NameDiscountPolicy());
            var results = benCalc.Calculate(emp);

            Assert.AreEqual(results.BaseAnnualCost, 1500);
            Assert.AreEqual(results.DiscountApplied, true);
            Assert.AreEqual(results.DiscountedAnnualCost, 1450);            
        }

        [TestMethod]
        public void EmployeeWithMultipleDependentsAllWithDiscount()
        {
            var emp = new EmployeeFactory().CreateEmployee(52000, 26);
            emp.FirstName = "Adrienne";
            emp.Dependents.Add(new DependentFactory().CreateDependent("Aaron", "Doe"));
            emp.Dependents.Add(new DependentFactory().CreateDependent("Andrew", "Doe"));
            emp.Dependents.Add(new DependentFactory().CreateDependent("Arnold", "Doe"));
            var benCalc = new BenefitCalculatorService(new NameDiscountPolicy());

            var results = benCalc.Calculate(emp);

            Assert.AreEqual(results.BaseAnnualCost, 2500);
            Assert.AreEqual(results.DiscountApplied, true);
            Assert.AreEqual(results.DiscountedAnnualCost, 2250);            
        }
    }
}
