using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI button;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI coins;
    [SerializeField] TextMeshProUGUI gems;
    [SerializeField] TextMeshProUGUI progress;

    GameState gameState;

    private string path;
    private bool fileNotExist = false;
    GameProgress gameProgress;

    private void Awake()
    {
        path = Path.Combine(Application.persistentDataPath, "GameProgress.txt");
    }

    void Start()
    {
        gameState = GameObject.FindObjectOfType<GameState>();
        button.text = "START";
        title.text = "JUMPPOLIS";
        gameProgress = new GameProgress();
        LoadForFirstScreen();
        if (fileNotExist)
        {
            progress.text = $"Last played: -\n" +
                        $"Last on level: -\n" +
                        $"Last colleced coins: -\n" +
                        $"Last colleced gems: -";
        }
        else
        {
            progress.text = $"Last played: {gameProgress.lastPlayed}\n" +
                        $"Last played level: {gameProgress.onLevel}\n" +
                        $"Last colleced coins: {gameProgress.coin}\n" +
                        $"Last colleced gems: {gameProgress.gem}";
        }
    }

    void Update()
    {
        button.text = gameState.isWelcome ? "START" : "PLAY AGAIN";
        title.text = "JUMPPOLIS";
        if (!gameState.isWelcome)
        {
            progress.text = "";
        }
        if (!gameState.isWelcome && gameState.isPlayerWins)
        {
            title.text = "Player Wins";
        }
        else
        {
            if (!gameState.isPlayerWins && !gameState.isPlayerWins)
            {
                title.text = "Game Over";
            }
        }
        if (!gameState.isWelcome)
        {
            progress.text = "";
            coins.text = $"Coin(s): {gameState.coin.ToString()}";
            gems.text = $"Gem(s): {gameState.gem.ToString()}";
        }
    }

    public string LoadForFirstScreen()
    {
        string text = string.Empty;
        if (File.Exists(path))
        {
            using (StreamReader streamReader = File.OpenText(path))
            {
                string jsonString = streamReader.ReadToEnd();
                gameProgress = JsonUtility.FromJson<GameProgress>(jsonString);
            }
        }
        else
        {
            fileNotExist = true;
        }
        return text;
    }

    [System.Serializable]
    public class GameProgress
    {
        public int coin;
        public int gem;
        public int live;
        public bool isWelcome;
        public bool isPlayerWins;
        public bool isKeyCollect;
        public int onLevel;
        public string lastPlayed;

    }
}
