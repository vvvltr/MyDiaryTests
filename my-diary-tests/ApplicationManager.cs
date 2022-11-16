using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

public class ApplicationManager
{
    private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
    
    public IWebDriver driver;
    public IDictionary<string, object> vars {get; private set;}
    public IJavaScriptExecutor js;
    public StringBuilder verificationErrors;
    public string baseURL;

    public NavigationHelper navigation;
    public LoginHelper authentication;
    public NoteHelper posting;

    public bool loggedIn;

    private ApplicationManager()
    {
        driver = new ChromeDriver();
        js = (IJavaScriptExecutor)driver;
        vars = new Dictionary<string, object>();
        baseURL = "https://www.my-diary.org/";
        verificationErrors = new StringBuilder();
        authentication = new LoginHelper(this);
        navigation = new NavigationHelper(this);
        posting = new NoteHelper(this);
        loggedIn = false;
    }

    public static ApplicationManager GetInstance()
    {
        if (!app.IsValueCreated)
        {
            ApplicationManager newInstance = new ApplicationManager();
            newInstance.Navigation.OpenHomePage();
            app.Value = newInstance;
        }

        return app.Value;
    }
    
    ~ApplicationManager()
    {
        try
        {
            driver.Quit();
        }
        catch (Exception)
        { 
            //ignore
        }
    }

    
    public IWebDriver Driver { get { return driver; } }
    public NavigationHelper Navigation { get { return navigation; } }
    public LoginHelper Authentication { get { return authentication; } }
    public NoteHelper Posting { get { return posting;  } }

    public void Stop()
    {
        driver.Quit();
    }
}