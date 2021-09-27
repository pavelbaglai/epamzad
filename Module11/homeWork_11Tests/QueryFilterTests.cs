using Microsoft.VisualStudio.TestTools.UnitTesting;
using homeWork_11;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_11.Tests
{
    [TestClass]
    public class QueryFilterTests
    {
        [TestMethod]
        public void QueryFilter_QueryFilterTest()
        {
            Filter filter = new Filter("-Ivan D -English -20150101 -20180101 -2 -8 -1");
            Assert.ThrowsException<ArgumentNullException>(() => Query.QueryFilter(null, filter));
        }

        [TestMethod]
        public void FilterNullArg_QueryFilterTest()
        {
            List<Student> list = new List<Student>();
            list.Add(new Student("Test","test",new DateTime(2019,1,1),1 ));
            Assert.ThrowsException<ArgumentNullException>(() => Query.QueryFilter(list, null));
        }
        
    }
}