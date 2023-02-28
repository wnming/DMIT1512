using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataInformation
{
    //main screen
    public static string buttonText = "Start Game";
    public static string title = "Space Invaders";
    public static string message = "Have fun wandering in the space!";
    public static Color messageColor = Color.white;
    public static string alienWins = "Alien Wins";
    public static string playerWins = "Player Wins";
    public static int playerScore = 0;
    //current leve
    public static int onLevel = 0;
    //num of aliens
    public static int numOfAliens = 0;
    public const int level1NumOfAliens = 24;
    public const int level2NumOfAliens = 25;
        //speed
    public static float alienSpeed = 0;
    public const float level1Speed = 0.3f;
    public const float level2Speed = 0.6f;
        //move
    public static int alienMove = 0;
    public const int level1Move = 25;
    public const int level2Move = 12;
    public static string alienShipsText = "Alien Ship(s): ";
    //player
    public const int InitialPlayerLife = 3;
    public static int playerLife = 3;
    public static string playerLifeText = "Player Life(s): ";

    private static GameSceneManager gameSceneManager = new GameSceneManager();

    public static void SetMessage(string win)
    {
        message = $"{win} Wins" + ", Player Score: " + playerScore;
    }

    public static void LoadLevelTwo()
    {
        gameSceneManager.LoadLevelTwo();
    }

    public static void LoadMainMenu()
    {
        gameSceneManager.LoadMainMenu();
    }
}
