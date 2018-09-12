using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Driver
{
    public class IE
    {
        public static RemoteWebDriver Build()
        {
            Uri uri = new Uri(ConfigurationManager.AppSettings["SeleniumServerURL"]);

            var ieOption = new InternetExplorerOptions();

            return new RemoteWebDriver(uri, ieOption);
        }

        public static InternetExplorerDriver BuildLocal()
        {
            var ieOptions = new InternetExplorerOptions();
            ieOptions.AcceptInsecureCertificates = false;
            ieOptions.EnsureCleanSession = false;
            ieOptions.IgnoreZoomLevel = true;
            ieOptions.InitialBrowserUrl = ConfigurationManager.AppSettings["BaseURL"];
            return new InternetExplorerDriver(ieOptions);
        }
    }
}
