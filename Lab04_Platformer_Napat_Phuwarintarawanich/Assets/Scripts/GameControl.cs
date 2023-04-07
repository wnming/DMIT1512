using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class GameControl : MonoBehaviour
{
    [SerializeField] AudioSource passLevel;
    [SerializeField] AudioSource dieAudio;

    public GameState currentGameState;
    GameSaveManager gameSaveManager;
    GameSceneManager gameSceneManager;

    private void Start()
    {
        currentGameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
        gameSaveManager = FindObjectOfType<GameSaveManager>();
        gameSceneManager = new GameObject("GameSceneManager").AddComponent<GameSceneManager>();
    }

    public void CollectKey()
    {
        currentGameState.isKeyCollect = true;
    }

    public void IncreaseLive()
    {
        if (currentGameState.live < 3)
        {
            currentGameState.live += 1;
        }
    }

    public void DecreaseLive()
    {
        currentGameState.live -= 1;
        if (currentGameState.live <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        dieAudio.Play();
        currentGameState.isWelcome = false;
        currentGameState.isKeyCollect = false;
        currentGameState.onLevel = 1;
        gameSceneManager.LoadGameOver();
    }

    public void CheckToAnotherLevel()
    {
        currentGameState.isWelcome = false;
        if (currentGameState.isKeyCollect)
        {
            passLevel.Play();
            if(currentGameState.onLevel == 1)
            {
                currentGameState.onLevel = 2;
                currentGameState.isKeyCollect = false;
                gameSceneManager.LoadLevelTwo();
            }
            else
            {
                currentGameState.isPlayerWins = true;
                currentGameState.onLevel = 1;
                gameSceneManager.LoadGameOver();
            }
        }
    }

    public void ResetLevel()
    {
        currentGameState.live = currentGameState.MaxLives;
        currentGameState.coin = 0;
        currentGameState.gem = 0;
        currentGameState.isKeyCollect = false;
        currentGameState.isPlayerWins= false;
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
