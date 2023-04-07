using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI button;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI coins;
    [SerializeField] TextMeshProUGUI gems;
    [SerializeField] TextMeshProUGUI highScoreNameTitle;
    [SerializeField] TextMeshProUGUI hightScoreName;
    [SerializeField] TextMeshProUGUI howToPlay;
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] Button okButton;

    GameState gameState;

    void Start()
    {
        gameState = GameObject.FindObjectOfType<GameState>();
        button.text = "START";
        title.text = "JUMPPOLIS";
        //okButton.gameObject.SetActive(false);
        //nameInput.gameObject.SetActive(false);
    }

    void Update()
    {
        button.text = gameState.isWelcome ? "START" : "PLAY AGAIN";
        title.text = "JUMPPOLIS";
        if (!gameState.isWelcome && gameState.isPlayerWins)
        {
            title.text = "Player Wins";
        }
        else
        {
            if(!gameState.isPlayerWins && !gameState.isPlayerWins){
                title.text = "Game Over";
            }
        }
        if (!gameState.isWelcome)
        {
            coins.text = $"Coin(s): {gameState.coin.ToString()}";
            gems.text = $"Gem(s): {gameState.gem.ToString()}";
        }
    }
}
