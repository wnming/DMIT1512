using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI button;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI highScore;
    [SerializeField] TextMeshProUGUI highScoreNameTitle;
    [SerializeField] TextMeshProUGUI hightScoreName;
    [SerializeField] TextMeshProUGUI howToPlay;
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] Button okButton;

    GameState gameState;

    void Start()
    {
        gameState = GameObject.FindObjectOfType<GameState>();
        button.text = "Start Game";
        title.text = "Pinball";
        title.fontSize = 200;
        okButton.gameObject.SetActive(false);
        nameInput.gameObject.SetActive(false);
    }

    void Update()
    {
        button.text = gameState.isWelcome ? "Start Game" : "Play Again";
        title.text = gameState.isWelcome ? "Pinball" : "Game Over";
        title.fontSize = gameState.isWelcome ? 200 : 150;
        if (!gameState.isWelcome)
        {
            score.text = $"Score: {gameState.score}";
            highScore.text = $"High Score: {gameState.highScore}";
            howToPlay.text = "";
            if (gameState.isHighScore)
            {
                nameInput.gameObject.SetActive(true);
                okButton.gameObject.SetActive(true);
                highScoreNameTitle.text = "Enter Name:";
                gameState.highScoreName = "";
            }
            hightScoreName.text = gameState.highScoreName;
        }
    }
}
