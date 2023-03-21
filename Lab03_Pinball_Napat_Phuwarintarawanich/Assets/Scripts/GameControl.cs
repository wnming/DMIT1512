using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class GameControl : MonoBehaviour
{
    public GameState currentGameState;
    GameSaveManager gameSaveManager;
    GameSceneManager gameSceneManager;

    private void Start()
    {
        currentGameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
        gameSaveManager = FindObjectOfType<GameSaveManager>();
        gameSceneManager = new GameObject("GameSceneManager").AddComponent<GameSceneManager>();
    }

    public void DecreaseLive()
    {
        currentGameState.live -= 1;
        if (currentGameState.live <= 0)
        {
            currentGameState.isWelcome = false;
            SaveCurrentScore();
            gameSceneManager.LoadGameOver();
        }
    }

    public void ResetCurrentLives()
    {
        currentGameState.live = 3;
    }

    public void IncreaseCurrentScore()
    {
        currentGameState.score += 1;
        if (currentGameState.score > currentGameState.highScore || currentGameState.score == currentGameState.highScore)
        {
            currentGameState.isHighScore = true;
            currentGameState.highScore = currentGameState.score;
        }
        else
        {
            currentGameState.isHighScore = false;
        }
    }

    public void SaveCurrentScore()
    {
        gameSaveManager.SaveToDisk();
    }

    public void LoadCurrentScore()
    {
        gameSaveManager.LoadFromDisk();
    }
}
