﻿using OpenQA.Selenium;
using System.Configuration;
using System;
using Framework.Driver;

namespace Framework.Helper
{
    public class DriverFactory
    {
        private IWebDriver _driver;

        public DriverFactory()
        {
            _driver = null;
        }

        public IWebDriver Initialize(string browser)
        {
            double timeout = Convert.ToDouble(ConfigurationManager.AppSettings["DefaultTimeout"]);

            if (_driver == null)
            {
                if (browser.Equals("Chrome"))
                {
                    if (Convert.ToBoolean(ConfigurationManager.AppSettings["Remote"]))
                    {
                        _driver = Chrome.Build();
                    }
                    else
                    {
                        _driver = Chrome.BuildLocal();
                    }
                }

                else if (browser.Equals("IE"))
                {
                    if (Convert.ToBoolean(ConfigurationManager.AppSettings["Remote"]))
                    {
                        _driver = IE.Build();
                    }
                    else
                    {
                        _driver = IE.BuildLocal();
                    }
                }

                else if (browser.Equals("Firefox"))
                {
                    if (Convert.ToBoolean(ConfigurationManager.AppSettings["Remote"]))
                    {
                        _driver = Firefox.Build();
                    }
                    else
                    {
                        _driver = Firefox.BuildLocal();
                    }
                }

                else
                {
                    throw new Exception("Driver not supported!");
                }
            }

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeout);

            return _driver;
        }
    }
}
