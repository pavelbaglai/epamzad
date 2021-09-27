using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework_9.Task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_9Tests.Task3
{
    [TestClass]
    public class CountdownTests
    {
        [TestMethod]
        public void NullMsg_CountdownTests()
        {
            // arrange  
            var msgManager = new Countdown();

            var listener = new Listener();
            listener.Register(msgManager);

            // act and assert  
            Assert.ThrowsException<ArgumentNullException>(() => msgManager.SendNewMsg("", 3000));
        }
    }
}
