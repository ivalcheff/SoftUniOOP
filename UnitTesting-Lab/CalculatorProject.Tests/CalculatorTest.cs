using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProject.Tests
{
    public class CalculatorTest
    {
        [Test]
        public void CalculatorAdd_ShouldReturnCorrect()
        {
            Calculator calculator = new Calculator();
            int result = calculator.Add(5, 6);
            Assert.AreEqual(11, result, $"Adding 5 and 6 should return 11, not {result}");
        }

        
        

    }
}
