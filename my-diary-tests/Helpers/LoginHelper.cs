﻿using System;
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
    public AccountData userData = new AccountData(Settings.Email, Settings.Password) {Nickname = Settings.Nickname};
    //public AccountData userData = new AccountData("vladislava.turina@yandex.ru","q2eueq0vl") { Nickname = "missilewhistle"};
    public LoginHelper(ApplicationManager appManager) : base(appManager) { }
    
    public void Login(AccountData accountData)
    {
        if (IsLoggedIn())
        {
            if (IsLoggedIn(accountData))
            {
                return;
            }
            Logout();
        }
        AppManager.navigation.OpenHomePage();
        driver.FindElement(By.LinkText("Авторизоваться")).Click();
        driver.FindElement(By.Id("InputEmail")).Click();
        driver.FindElement(By.Id("InputEmail")).SendKeys(accountData.Email);
        driver.FindElement(By.Id("InputPassword")).Click();
        driver.FindElement(By.Id("InputPassword")).SendKeys(accountData.Password);
        driver.FindElement(By.CssSelector(".col-lg-7 > .btn")).Click();
    }

    public void Logout()
    {
        driver.FindElement(By.CssSelector("#navbar1 > ol.nav.navbar-nav.ml-auto > li:nth-child(2) > a")).Click();
    }
    
    public bool IsLoggedIn()
    {
        try
        {
            var el = driver.FindElement(By.CssSelector("#navbar1 > ol.nav.navbar-nav.ml-auto > li.text-center"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        return true;
    }

    public bool IsLoggedIn(AccountData accountData)
    {
        string str = "Добро пожаловать, " + accountData.Nickname;
        IWebElement loginElement;
        try
        {
            loginElement = driver.FindElement(By.CssSelector("#navbar1 > ol.nav.navbar-nav.ml-auto > li.text-center"));
        }
        catch (Exception e)
        {
            return false;
        }

        string s = loginElement.Text;
        if (loginElement.Text.Equals(str))
        {
            return true;
        }
        return false;
    }
}