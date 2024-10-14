using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;


namespace MyFirstSeleniumProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void NunitSeleniumTest()
        {
            // Kui on soovi kasutada Chrome Drivereid, siis eemaldada rida 21-23 ning asendada järgmisega:
            // IWebDriver driver = new ChromeDriver(@"C:\Users\opilane\source\repos\MyFirstSeleniumProject\MyFirstSeleniumProject\Drivers\")
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = (@"C:\Program Files\Mozilla Firefox\firefox.exe"); //Täpsustan Firefox.exe asukohta kuna Geckodriver pärib valest asukohast registry editorist firefox.exe asukohta".
            IWebDriver driver = new FirefoxDriver(@"C:\Users\opilane\source\repos\MyFirstSeleniumProject\MyFirstSeleniumProject\Drivers\", options); 
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.tthk.ee/";

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.Until(driver => driver.Title == "TTHK – Tallinna Tööstushariduskeskus"); //Testime lihtsalt, et kas lehkülje tilte on "TTHK – Tallinna Tööstushariduskeskus"

            driver.Close();
            driver.Quit();

        }
    }
}