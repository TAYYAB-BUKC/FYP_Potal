using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MyGuid
/// </summary>
public class MyGuid
{
    public static string GetRandomPasswordForUpload()
    {
        char[] chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        string password = string.Empty;
        Random random = new Random();

        for (int i = 0; i < 1; i++)
        {
            int x = random.Next(0, 25);
            //For avoiding Repetation of Characters
            if (!password.Contains(chars.GetValue(x).ToString()))
                password += chars.GetValue(x);
            else
                i = i - 1;
        }
        for (int i = 0; i < 1; i++)
        {
            int x = random.Next(0, 25);
            //For avoiding Repetation of Characters
            if (!password.Contains(chars.GetValue(x).ToString()))
                password += chars.GetValue(x);
            else
                i = i - 1;
        }
        for (int i = 0; i < 1; i++)
        {
            int x = random.Next(0, 25);
            //For avoiding Repetation of Characters
            if (!password.Contains(chars.GetValue(x).ToString()))
                password += chars.GetValue(x);
            else
                i = i - 1;
        }
        for (int i = 0; i < 1; i++)
        {
            int x = random.Next(0, 25);
            //For avoiding Repetation of Characters
            if (!password.Contains(chars.GetValue(x).ToString()))
                password += chars.GetValue(x);
            else
                i = i - 1;
        }
        for (int i = 0; i < 1; i++)
        {
            int x = random.Next(0, 25);
            //For avoiding Repetation of Characters
            if (!password.Contains(chars.GetValue(x).ToString()))
                password += chars.GetValue(x);
            else
                i = i - 1;
        }
        for (int i = 0; i < 1; i++)
        {
            int x = random.Next(0, 25);
            //For avoiding Repetation of Characters
            if (!password.Contains(chars.GetValue(x).ToString()))
                password += chars.GetValue(x);
            else
                i = i - 1;
        }

        return password;
    }
}
