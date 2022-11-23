namespace my_diary_tests;

public class AuthBase : TestBase
{
    protected ApplicationManager appManager;
    [SetUp]
    public void SetUp()
    {
        appManager = ApplicationManager.GetInstance();
        appManager.Navigation.OpenHomePage();
        appManager.Authentication.Login(appManager.Authentication.userData);
    }
    
}