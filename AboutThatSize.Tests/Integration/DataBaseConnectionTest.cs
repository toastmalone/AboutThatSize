using AboutThatSize.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AboutThatSize.Tests.Integration
{
    [TestClass]
    public class DataBaseConnectionTest
    {
        [TestInitialize]
        public void Init ()
        {

        }

        [TestMethod]
        public void OpenConnectionToDatabaseTest()
        {
            AboutThatSizeContext aboutThatSizeContext = new AboutThatSizeContext();
            Assert.IsTrue(aboutThatSizeContext.Database.CanConnect());
            Assert.IsNotNull(aboutThatSizeContext.Items.Take(1));
        }
    }
}
