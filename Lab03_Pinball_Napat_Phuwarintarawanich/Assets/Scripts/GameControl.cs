using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameControl : MonoBehaviour
{
    GameState currentGameState;
    GameSaveManager gameSaveManager;

    private void Start()
    {
        currentGameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
        gameSaveManager = FindObjectOfType<GameSaveManager>();
    }

    public void DecreaseLive()
    {
        currentGameState.live -= 1;
    }

    public void ResetCurrentLives()
    {
        currentGameState.live = 3;
    }

    public void IncreaseCurrentScore()
    {
        currentGameState.score += 1;
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
