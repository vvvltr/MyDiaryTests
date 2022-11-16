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

public class LoginHelper : HelperBase
{
    public AccountData userData = new AccountData("vladislava.turina@yandex.ru", "q2eueq0vl");
    public LoginHelper(ApplicationManager appManager) : base(appManager) { }
    
    public void Login(AccountData accountData)
    {
        if (AppManager.loggedIn==false)
        {
            driver.FindElement(By.LinkText("Авторизоваться")).Click();
            driver.FindElement(By.Id("InputEmail")).Click();
            driver.FindElement(By.Id("InputEmail")).SendKeys(accountData.Email);
            driver.FindElement(By.Id("InputPassword")).Click();
            driver.FindElement(By.Id("InputPassword")).SendKeys(accountData.Password);
            driver.FindElement(By.CssSelector(".col-lg-7 > .btn")).Click();
            AppManager.loggedIn = true;
        }
    }

    public void Logout()
    {
        driver.FindElement(By.CssSelector("#navbar1 > ol.nav.navbar-nav.ml-auto > li:nth-child(2) > a")).Click();
    }
    
    public bool IsLogged()
    {
        var el = driver.FindElement(By.CssSelector("#navbar1 > ol.nav.navbar-nav.ml-auto > li.text-center"));
        return true;
    }

    public bool IsLogged(AccountData accountData)
    {
        return AppManager.authentication.IsLogged();
    }
}