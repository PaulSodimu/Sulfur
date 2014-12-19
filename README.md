<h1>Sulfur</h1>

<p>
  A <a href="">Selenium Webdriver</a> wrapper that will help you to build an automated testing framework 
  that follows the page object pattern. 
</p>

<h2>How to install it</h2>

<p>
You can add Sulfur to your project by running the nuget command in the package manager console.
</p>

<pre>Install-Package Sulfur</pre>

<h2>How to use it</h2>

<p>
Once the installation has been completed three files will be added to your project.
<ul>
  <li>An app.config file</li>
  <li>A class called pages (in a folder called pages)</li>
  <li>A demo page called HomePage (in a folder called pages)</li>
</ul>
</p>

For each page in your system, you will need to create a new class for it that inherits from the Sulfur page base class.
<pre>
using Sulfur.Common;
using System; 

namespace TestSulfur.Pages
{
    //All pages should inherit from the page base class
    public class HomePage : Page
    {
         
    }
}
</pre>

Once you have created your page, add a new property for it in the pages.cs class.

<pre>
using OpenQA.Selenium.Support.PageObjects;
using Sulfur;
using System;
using System.Collections; 

namespace TestSulfur.Pages
{ 
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
</pre>

<p>Now we can setup the tests. Create a new unit test project then add a reference to the sulfur library and your framework project. Copy the app.config file into the test project then open it to edit.<br /> In the appSettings section, set the errorCaptureLocation value to a location you want error screenshots to be saved to. Also choose the browser you want to use for your tests by uncommenting the appropriate line.
</p>
<pre>
  <appSettings>

    <add key="ErrorCaptureLocation" value="C:\Temp\"/>

    <!--Choose browser to run test-->

    <add key="Browser" value="OpenQA.Selenium.Firefox.FirefoxDriver"/>
    <!--add key="Browser" value="OpenQA.Selenium.Chrome.ChromeDriver"/-->
    <!--<add key="Browser" value="OpenQA.Selenium.IE.InternetExplorerDriver"/>-->

  </appSettings>
</pre>

<p>
  In the environments section, you need to add a new element to the environment element for each page you have. The name of the element must be the same as the name of the page object. You must also add a url for the page and a page title.
</p>

<pre>
  <Environments>

    <!--Prod-->
    <Environment>
      <add name="HomePage" url="http://www.paulsodimu.co.uk" pageTitle="PaulSodimu.co.uk" />
    </Environment> 

  </Environments>
</pre>

<p>
Finally we can write tests. Create a new unit test class. The Sulfur Browser class gives you access to the browser and some methods to control it. The Pages class will give acess to the pages of your system.
</p>

<pre>
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
</pre>
