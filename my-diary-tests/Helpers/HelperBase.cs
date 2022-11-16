using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using my_diary_tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace my_diary_tests;

public class HelperBase
{
    public ApplicationManager AppManager;
    public IWebDriver driver;
    protected bool acceptNextAlert = true;

    public HelperBase(ApplicationManager appManager)
    {
        this.AppManager = appManager;
        this.driver = appManager.driver;
    }
}