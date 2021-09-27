using System;
using System.Reflection;

namespace NUnitTestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assembly testAssembly = Assembly.LoadFrom(@"C:\Users\Andrey.Novov\Documents\Visual Studio 2015\Projects\NUnitTestRunner-master\TestSample\bin\Debug\TestSample.dll");
            var testAssembly = Assembly.LoadFile(args[0]);

            var testRunner = new TestRunner(testAssembly);

            testRunner.RunTests();

            Console.ReadLine();
        }
    }
}
