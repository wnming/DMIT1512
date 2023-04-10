using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public int MaxLives => 3;
    public int coin = 0;
    public int gem = 0;
    public int live = 3;
    public bool isWelcome = true;
    public bool isPlayerWins = false;
    public bool isKeyCollect = false;
    public int onLevel;
    public string lastPlayed = string.Empty;

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
        onLevel = 1;
    }
}