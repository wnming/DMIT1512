using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public int score = 0;
    public int live = 3;
    public int highScore = 0;
    public bool isWelcome = true;
    GameSceneManager gameSceneManager = new GameSceneManager();
    GameTester gameTester;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameState");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        gameTester = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameTester>();
        isWelcome = true;
    }

    private void Update()
    {
        Debug.Log(live);
        if (live <= 0)
        {
            isWelcome = false;
            gameTester.SaveCurrentScore();
            gameSceneManager.LoadGameOver();
        }
        if (score > highScore)
        {
            highScore = score;
        }
    }
}