using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace NUnitTestRunner
{
    public class TestRunner
    {
        private readonly Assembly _testAssembly;

        public TestRunner(Assembly testAssembly)
        {
            _testAssembly = testAssembly;
        }

        public void RunTests()
        {
            var testTypes = GetTestTypes();

            foreach (var testType in testTypes)
            {
                RunTestType(testType);
                
            }
        }

        ICollection<Type> GetTestTypes()
        {
            return _testAssembly.ExportedTypes
                .Where(x => x.IsClass && x.GetCustomAttributes<TestFixtureAttribute>().Any())
                .ToList();
        }

        void RunTestType(Type testType)
        {
            var testMethods = GetTestMethods(testType);
            var testSetupMethod = GetStartupMethods(testType);
            var testTeardownMethod = GetTeardownMethods(testType);

            if (!testMethods.Any())
                return;

            var instance = Activator.CreateInstance(testType);

            #region testMethods
            
            foreach (var testMethod in testMethods)
            {
                var testCaseAttributes = GetTestCaseAttributes(testMethod);

                var arguments = testCaseAttributes.Any()
                    ? testCaseAttributes.Select(x => x.Arguments)
                    : Enumerable.Repeat(default(object[]), 1);

                foreach (var args in arguments)
                {
                    try
                    {
                        testSetupMethod?.Invoke(instance, default(object[]));
                        var argsString = args == null ? string.Empty : string.Join(", ", args);
                        Console.WriteLine($"Run method {testType.Name}.{testMethod.Name}({argsString})");
                        testMethod?.Invoke(instance, args);
                        Console.WriteLine("   success");
                        testTeardownMethod?.Invoke(instance, default(object[]));
                    }
                    catch (TargetInvocationException exception)
                    {
                        if (exception.InnerException is AssertionException)
                        {
                            Console.WriteLine(exception.InnerException.Message);
                        }
                        else
                        {
                            Console.WriteLine($"Unexpected: {exception.Message}");
                        }
                    }
                }
            }
            #endregion
        }

        ICollection<MethodInfo> GetTestMethods(Type testType)
        {
            return testType.GetRuntimeMethods()
                .Where(x => x.GetCustomAttributes<TestAttribute>().Any() ||
                            x.GetCustomAttributes<TestCaseAttribute>().Any())
                .ToList();
        }

        MethodInfo GetStartupMethods(Type testType)
        {
            return testType.GetRuntimeMethods()
               .FirstOrDefault(x => x.GetCustomAttributes<SetUpAttribute>().Any()); 
        }

        MethodInfo GetTeardownMethods(Type testType)
        {
            return testType.GetRuntimeMethods()
                .FirstOrDefault(x => x.GetCustomAttributes<TearDownAttribute>().Any());
        }

        ICollection<TestCaseAttribute> GetTestCaseAttributes(MethodInfo testMethod)
        {
            return testMethod.GetCustomAttributes<TestCaseAttribute>().ToList();
        }
    }
}
