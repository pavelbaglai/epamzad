using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework3_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_3Tests
{
    [TestClass()]
    public class NewtonTests
    {
        [TestMethod()]
        public void NewtonExec_Normal_Test()
        {
            // arrange  
            double eps = 0;
            double dx = 9.0;
            int x0 = 2;
            Newton newton = new Newton(eps);
            double expected = 3;

            // act  
            double result = newton.Exec(x0, dx);

            // assert  
            Assert.AreEqual(expected, result, "Correctly");
        }
        [TestMethod()]
        public void NewtonExec_NegativeValues_Test()
        {
            // arrange  
            double eps = -0.0001;
            double dx = -8;
            int x0 = 2;
            Newton newton = new Newton(eps);
            ArgumentOutOfRangeException expectedException = null;

            // act  
            try
            {
                double result = newton.Exec(x0, dx);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                expectedException = ex;
            }


            // assert  
            Assert.IsNotNull(expectedException);
        }
    }
}