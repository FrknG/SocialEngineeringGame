using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class PasswordChecker : MonoBehaviour
{

    [SerializeField] public string Password;
    [SerializeField] public string StringtoAdd;
    [SerializeField] public Button stringbutton;
    [SerializeField] public Text PasswordText;
    [SerializeField] public Text scoreText;

 

    public void ShowScore(string Password)
    {
        AddText(stringbutton);

       
    }


    public void AddText(Button textToAdd)
    {
        textToAdd.GetComponent<Text>().text = "$$$";
        Password += textToAdd.GetComponent<Text>();
        PasswordText.text = Password;
    }

    public int CheckPasswordStrength(string password)
    {
        int score = 0;

        // Check the length of the password
        if (password.Length >= 8)
        {
            score += 2;
        }

        // Check for the presence of uppercase and lowercase letters, numbers, and special characters
        if (Regex.IsMatch(password, @"\d+")) score++;
        if (Regex.IsMatch(password, @"[a-z]")) score++;
        if (Regex.IsMatch(password, @"[A-Z]")) score++;
        if (Regex.IsMatch(password, @"[^a-zA-Z0-9]")) score++;

        // Check for common words or patterns
        if (Regex.IsMatch(password, @"password", RegexOptions.IgnoreCase)) score = 0;

        if (Regex.IsMatch(password, @"psswrd", RegexOptions.IgnoreCase)) score = 0;

        if (Regex.IsMatch(password, @"12345", RegexOptions.IgnoreCase)) score = 0;
        if (Regex.IsMatch(password, @"qwerty", RegexOptions.IgnoreCase)) score = 0;

        return score;

       
    }

}
