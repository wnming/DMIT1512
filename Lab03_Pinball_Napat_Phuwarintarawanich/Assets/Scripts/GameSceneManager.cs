using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    GameState gameState;
    private void Start()
    {
        gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(0);
    }

    public void SaveNewHighScore()
    {
        //Debug.Log("SaveNewHighScore");
        //GameObject.FindGameObjectWithTag("GameState").GetComponent<GameControl>().SaveCurrentScore();
        //Debug.Log("SaveToDisk");
        //gameState.name = gameState.highScoreName;
    }
}
