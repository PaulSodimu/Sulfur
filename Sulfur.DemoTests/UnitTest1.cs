using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sulfur.DemoFramework.Pages;

namespace Sulfur.DemoTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void SetupTest()
        {
            Browser.Open();
        }

        [TestMethod]
        public void TestMethod()
        {
            //Act
            Pages.HomePage.Goto();

            //Assert
            Assert.IsTrue(Pages.HomePage.IsAt());
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Browser.Quit();
        }
    }
}
