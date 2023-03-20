using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public int score = 0;
    public int live = 3;
    public int highScore = 0;
    public bool isWelcome = true;
    public bool isHighScore = false;
    public string highScoreName;

    GameSceneManager gameSceneManager;
    GameControl gameControl;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameState");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        //GameObject gameObject = new GameObject("DetectPlayer");
        gameSceneManager = new GameObject("GameSceneManager").AddComponent<GameSceneManager>();
    }

    private void Start()
    {
        //gameSceneManager = GameObject.FindObjectOfType<GameSceneManager>();
        gameControl = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameControl>();
        //gameSceneManager = GameObject.FindGameObjectWithTag("GameSceneManager").GetComponent<GameSceneManager>();
        isWelcome = true;
        isHighScore = false;
    }

    private void Update()
    {
        if (live <= 0)
        {
            isWelcome = false;
            gameControl.SaveCurrentScore();
            gameSceneManager.LoadGameOver();
        }
        if (score > highScore || score == highScore)
        {
            isHighScore = true;
            highScore = score;
        }
        else
        {
            isHighScore = false;
        }
    }
}