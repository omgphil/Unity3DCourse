using UnityEngine;


public enum Screen
{
    MainMenu,
    Password,
    Win
};

public class Hacker : MonoBehaviour
{
    private const string menuHint = "Enter menu at any time to return";
    // Game Configuration
    private readonly string[] level1Passwords = { "pear", "orange", "apple", "grape", "banana" };
    private readonly string[] level2Passwords = { "dragon", "nightelf", "prisoner", "adventure", "quiver" };
    private readonly string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };

    // Game State
    public int Level { get; set; }
    public Screen CurrentScreen { get; set; }
    private string password;

    void Start()
    {
        ShowMainMenu();
    }

    private void ShowMainMenu()
    {
        CurrentScreen = Screen.MainMenu;
        Terminal.ClearScreen();

        Terminal.WriteLine("What would you like to hack into?\nSolve the anogram!!!");
        Terminal.WriteLine("Press 1 for the Grocery Store");
        Terminal.WriteLine("Press 2 for the Fantasy World");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine(menuHint + "\n");

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
        } else if (string.Equals(input.ToLower(), "quit") || string.Equals(input.ToLower(), "exit") || string.Equals(input.ToLower(), "close"))
        {
            Terminal.WriteLine("If on the Web, close the tab!");
            Application.Quit();
        }
        else if (CurrentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (CurrentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

    }

    private void CheckPassword(string input)
    {
        if (string.Equals(input.ToLower().Trim(), password))
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    private void DisplayWinScreen()
    {
        CurrentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    private void ShowLevelReward()
    {
        switch (Level)
        {
            case 1:
                Terminal.WriteLine(@" ,--./,-.
/,-._.--~\
 __}  {
\`-._,-`-,
 `._,._,'  ");
                break;
            case 2:
                Terminal.WriteLine(@"      . 
 .>   )\;`a__
(  _ _)/ /-."" ~~
 `( )_) /
  < _ < _ ");
                break;
            case 3:
                Terminal.WriteLine(@"     |     | |
    / \    | |
   |--o|===|-|
   |---|   | |
  /     \  | |
 |       |=| |
 |_______| |_|
  |@| |@|  | |
___________|_|_");
                break;
            default:
                Debug.LogError("Invalid Error");
                break;
        }

        Terminal.WriteLine("\nYou Win!!!");
        Terminal.WriteLine(menuHint);
    }

    private void RunMainMenu(string input)
    {
        bool isValidNumber = (int.TryParse(input, out int number) && number < 4 && number > 0);
        if (isValidNumber)
        {
            Level = number;
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    private void AskForPassword()
    {
        CurrentScreen = Screen.Password;
        Terminal.ClearScreen();

        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
    }

    private void SetRandomPassword()
    {
        switch (Level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid Choice");
                break;
        }
    }
}
