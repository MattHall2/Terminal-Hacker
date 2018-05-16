using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game configuration data
    const string menuHint = " \n You may type menu at any time";
    string[] level1Passwords = { "stop", "class", "string", "password", "select", "object" };
    string[] level2Passwords = { "pegasus", "spaceship", "stars", "planet", "galaxy", "orion" };
    string[] level3Passwords = { "edwardsairbase", "airforce", "unidentified", "creature", "extraterrestrial" };


    //Game State
    int level;

    enum Screen {MainMenu, Password, Win};
    Screen currentScreen;

    string password;

    //Initialization
    void Start()
    {
        ShowMainMenu("Are you ready Player 1?");
    }

    void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Who is the target?");
        Terminal.WriteLine("Press 1 for your neighbors WiFi");
        Terminal.WriteLine("Press 2 for NASA");
        Terminal.WriteLine("Press 3 for Area 51");
    }

    

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu("Welcome back");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            checkPassword(input);
        }
    }

    void RunMainMenu (string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }

        else if (input == "molly") //easter egg
        {
            Terminal.WriteLine("Hello Beautiful"); 
        }
        else
        {
            Terminal.WriteLine("Please follow instructions");
            Terminal.WriteLine(menuHint);
        }
    }
    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter the passcode, hint: \n " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
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
                Debug.LogError("Invalid level number");
                break;

        }
    }

    void checkPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Your neighbors are so confused.");
                break;
            case 2:
                Terminal.WriteLine("You have control of the launch codes.");
                break;
            case 3:
                Terminal.WriteLine("Welcome to Area 51.");
                break;
            default:
                Debug.LogError("Invalid level");
                break;
        }
        
    }
}
