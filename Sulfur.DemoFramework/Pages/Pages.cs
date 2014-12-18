using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections; 

namespace Sulfur.DemoFramework.Pages
{
    //This class allows access to system pages through the tests
    public static class Pages
    { 
        public static HomePage HomePage
        {
            get
            {
                var homePage = new HomePage();
                PageFactory.InitElements(Browser.Driver, homePage);
                return homePage;
            }
        }
    }
}
