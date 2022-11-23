using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

public class NoteHelper : HelperBase
{
    public NoteHelper(ApplicationManager appManager) : base(appManager) { }
    
    public void CreateNote(NoteData noteData)
    {
        driver.Navigate().GoToUrl("https://www.my-diary.org/edit/a/new");
        driver.FindElement(By.CssSelector("[id='etitle']")).Click();
        driver.FindElement(By.CssSelector("[id='etitle']")).SendKeys(noteData.Header);
        driver.FindElement(By.CssSelector("[id='entry']")).Click();
        driver.FindElement(By.CssSelector("[id='entry']")).Click();
        driver.FindElement(By.CssSelector("[id='entry']")).Clear();
        driver.FindElement(By.CssSelector("[id='entry']")).SendKeys(noteData.Content);
        driver.FindElement(By.Id("tags")).Click();
        driver.FindElement(By.Id("tags")).SendKeys("#hashtag");
        driver.FindElement(By.Id("savebutton2")).Click();
    }

    public string GetLastNoteId()
    {
        driver.Navigate().GoToUrl("https://www.my-diary.org/edit/a/lookup");
        IList<IWebElement> elements = driver.FindElements(By.CssSelector("[class='row diary_entry mt-1']"));
        string[] values = new string[elements.Count];
        for (int i = 0; i < elements.Count; i++)
        {
            values[i] = elements[i].FindElement(By.CssSelector("[class='dnav']")).GetAttribute("data-entryid");
        }
        return values[elements.Count-1];
    }

    public int GetNotesInfo()
    {
        driver.Navigate().GoToUrl("https://www.my-diary.org/edit/a/lookup");
        IList<IWebElement> elements = driver.FindElements(By.CssSelector("[class='row diary_entry mt-1']"));
        return elements.Count;
    }
    
    public void DeleteNote()
    {
        var el = GetLastNoteId();
        string path = "https://www.my-diary.org/edit/a/eraseentry/" + el;
        driver.Navigate().GoToUrl(path);
        Thread.Sleep(100);
        driver.FindElement(By.CssSelector("#mainbody > div.col-lg-12.col-lg-offset-0.mt2 > div > form > input[type=submit]:nth-child(3)")).Click();
    }
}