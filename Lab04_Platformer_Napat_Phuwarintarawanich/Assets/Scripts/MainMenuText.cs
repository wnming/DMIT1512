using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI button;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI coins;
    [SerializeField] TextMeshProUGUI gems;
    [SerializeField] TextMeshProUGUI progress;

    GameState gameState;
    GameSaveManager gameSaveManager;

    void Start()
    {
        //gameSaveManager = GameObject.FindObjectOfType<GameSaveManager>();
        gameState = GameObject.FindObjectOfType<GameState>();
        button.text = "START";
        title.text = "JUMPPOLIS";
        //gameState.lastPlayed = string.IsNullOrEmpty(gameState.lastPlayed) ? "-" : gameState.lastPlayed;
        //progress.text = gameSaveManager.LoadFromDisk();
    }

    void Update()
    {
        button.text = gameState.isWelcome ? "START" : "PLAY AGAIN";
        title.text = "JUMPPOLIS";
        //if (gameState.isWelcome)
        //{
        //    //gameState.lastPlayed = string.IsNullOrEmpty(gameState.lastPlayed) ? "-" : gameState.lastPlayed;
        //    progress.text = $"Last played: {gameState.lastPlayed}\n" +
        //                    $"Last played level: {gameState.onLevel}\n" +
        //                    $"Last colleced coins: {gameState.lastPlayed}\n" +
        //                    $"Last colleced gems: {gameState.lastPlayed}";
        //}
        if (!gameState.isWelcome && gameState.isPlayerWins)
        {
            title.text = "Player Wins";
        }
        else
        {
            if(!gameState.isPlayerWins && !gameState.isPlayerWins){
                title.text = "Game Over";
            }
        }
        if (!gameState.isWelcome)
        {
            progress.text = "";
            coins.text = $"Coin(s): {gameState.coin.ToString()}";
            gems.text = $"Gem(s): {gameState.gem.ToString()}";
        }
    }
}
