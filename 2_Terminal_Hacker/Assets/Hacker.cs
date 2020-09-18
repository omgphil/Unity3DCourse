using System;
using UnityEngine;


public enum Screen
{
    MainMenu,
    Password,
    Win
};

public class Hacker : MonoBehaviour
{
    public int Level { get; set; }
    public Screen CurrentScreen { get; set; }

    void Start()
    {
        ShowMainMenu();
    }

    private void ShowMainMenu()
    {
        CurrentScreen = Screen.MainMenu;
        Terminal.ClearScreen();

        Terminal.WriteLine("What would you like to hack into?\n");
        Terminal.WriteLine("Press 1 for the Grocery Store");
        Terminal.WriteLine("Press 2 for the Fantasy World");
        Terminal.WriteLine("Press 3 for NASA\n");

        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return;
        }

        if (string.Equals(input.ToLower(), "menu"))
        {
            ShowMainMenu();
        } else if (CurrentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
       
    }

    private void RunMainMenu(string input)
    {
        if (string.Equals(input, "1"))
        {
            Level = 1;
            StartGame();
        }
        else if (string.Equals(input, "2"))
        {
            Level = 2;
            StartGame();
        }
        else if (string.Equals(input, "3"))
        {
            Level = 3;
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    private void StartGame()
    {
        CurrentScreen = Screen.Password;
        Terminal.WriteLine($"You have chosen Level {Level}");
        Terminal.WriteLine("Please enter your password");
    }
}
