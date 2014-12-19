<h1>Sulfur</h1>

<p>
  A <a href="">Selenium Webdriver</a> wrapper that will help you to build an automated testing framework 
  that follows the page object pattern. 
</p>

<h2>How to install it</h2>

<p>
You can add Sulfur to you project by running the nuget command in the package manager console.
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
