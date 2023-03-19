using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameTester : MonoBehaviour
{
    //[SerializeField] InputAction IncreaseScore;
    //[SerializeField] InputAction DecreaseScore;
    //[SerializeField] InputAction ResetScore;
    //[SerializeField] InputAction SaveScore;
    //[SerializeField] InputAction LoadScore;
    //[SerializeField] InputAction TrySaveHighScore;

    GameState currentGameState;

    private void Start()
    {
        currentGameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
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

    void DecreaseCurrentScore()
    {
        currentGameState.score -= 1;
    }

    void ResetCurrentScore()
    {
        currentGameState.score = 0;
    }

    public void SaveCurrentScore()
    {
        FindObjectOfType<GameSaveManager>().SaveToDisk();
    }

    void LoadCurrentScore()
    {
        FindObjectOfType<GameSaveManager>().LoadFromDisk();
    }
}
