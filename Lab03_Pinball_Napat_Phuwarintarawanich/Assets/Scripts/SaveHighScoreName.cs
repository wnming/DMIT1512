using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveHighScoreName : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;
    GameState gameState;
    GameControl gameControl;
    void Start()
    {
        gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
        gameControl = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameControl>();
    }

    public void SaveNewHighScore()
    {
        gameState.name = gameState.highScoreName = nameInput.text;
        gameControl.SaveCurrentScore();
        gameState.isHighScore = false;
    }
}
