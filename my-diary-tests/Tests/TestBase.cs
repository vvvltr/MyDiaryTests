using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace my_diary_tests;

public class TestBase
{
    protected ApplicationManager appManager;
    [SetUp]
    public void SetUp()
    {
        appManager = ApplicationManager.GetInstance();
    }
    
}