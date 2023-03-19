using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI button;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI score;

    GameState gameState;

    void Start()
    {
        gameState = GameObject.FindObjectOfType<GameState>();
        button.text = "Start Game";
        title.text = "Pinball";
        title.fontSize = 200;
        //score.text = $"High Score: {gameState.highScore}";
    }

    // Update is called once per frame
    void Update()
    {
        button.text = gameState.isWelcome ? "Start Game" : "Play Again";
        title.text = gameState.isWelcome ? "Pinball" : "Game Over";
        title.fontSize = gameState.isWelcome ? 200 : 150;
        score.text = gameState.isWelcome ? $"High Score: {gameState.highScore}" : $"Score: {gameState.score}";
    }
}
