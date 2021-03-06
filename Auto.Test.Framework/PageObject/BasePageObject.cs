﻿using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace Auto.Test.Framework
{
    public abstract class BasePageObject<TE, TA>: IBasePageObject<TE, TA> 
        where TE:BasePageElements,new() 
        where TA:BasePageAssert<TE>, new ()
    {
        private string _url;
        protected readonly IWebDriver WebDriver;
        private IConfiguration _configuration;

        public BasePageObject(IBrowserDriver browserDriver)
        {
            WebDriver = browserDriver.WebDriver;
        }
        public IConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = new ConfigurationBuilder()
                                    .AddJsonFile("appconfig.json")
                                    .Build();
                }

                return _configuration;
            }
        }
        public virtual string BaseUrl {
            get
            {
                if (string.IsNullOrEmpty(_url))
                {
                    _url = Configuration["BaseUrl"];
                }
                return _url;
            }           
        }

        public TE Elements {get => new TE() { WebDriver = WebDriver };}
        public TA Asserts { get => new TA() { WebDriver = WebDriver }; }
        public virtual void Navigate(string part = "")
        {
            WebDriver.Navigate().GoToUrl(string.Concat(BaseUrl, part));
        }
    }
}
