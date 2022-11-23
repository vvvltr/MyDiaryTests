﻿namespace my_diary_tests;

public class AccountData
{
    public string Email { get; set; }
    public string Password { get; set; }

    public string Nickname { get; set; }
    
    public AccountData(string email, string password)
    {
        Email = email;
        Password = password;
    }
}