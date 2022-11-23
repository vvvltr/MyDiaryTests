using System.Xml;
using System.Xml.Serialization;

namespace my_diary_tests;

public class Settings
{
    public static string file = @"C:\Users\Владислава\RiderProjects\my-diary-tests\my-diary-tests\Settings.xml";

    private static XmlDocument _xmlDocument;
    
    private static string baseURL;
    private static string email;
    private static string password;
    private static string nickname;

    static Settings()
    {
        if (!System.IO.File.Exists(file)) { throw new Exception("Problem: settings file not found: " + file); }
        _xmlDocument = new XmlDocument();
        _xmlDocument.Load(file);
    }

    public static string BaseURL
    {
        get
        { if (baseURL == null)
            {
                XmlNode node = _xmlDocument.DocumentElement.SelectSingleNode("BaseURL");
                baseURL = node.InnerText;
            }
            return baseURL;
        }
    }

    public static string Email
    {
        get
        {
            if (email == null)
            {
                XmlNode node = _xmlDocument.DocumentElement.SelectSingleNode("Email");
                email = node.InnerText;
            }
            return email;
        }
    }
    
    public static string Password
    {
        get
        {
            if (password == null)
            {
                XmlNode node = _xmlDocument.DocumentElement.SelectSingleNode("Password");
                password = node.InnerText;
            }
            return password;
        }
    }
    
    public static string Nickname
    {
        get
        {
            if (nickname == null)
            {
                XmlNode node = _xmlDocument.DocumentElement.SelectSingleNode("Nickname");
                nickname = node.InnerText;
            }
            return nickname;
        }
    }
}