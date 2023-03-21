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

    //GameSceneManager gameSceneManager;
    //GameControl gameControl;

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
        isWelcome = true;
        isHighScore = false;
    }
}