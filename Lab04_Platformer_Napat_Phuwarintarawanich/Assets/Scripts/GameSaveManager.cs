using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI gemsText;

    protected GameState gameState;
    private string path;

    private void Awake()
    {
        path = Path.Combine(Application.persistentDataPath, "GameProgress.txt");
    }
    private void Start()
    {
        gameState = GameObject.FindObjectOfType<GameState>();
        LoadFromDisk();
    }

    private void Update()
    {
        coinText.text = $"Coins: {gameState.coin}";
        livesText.text = $"Lives: {gameState.live}";
        gemsText.text = $"Gems: {gameState.gem}";
    }

    public string LoadFromDisk()
    {
        string text = string.Empty;
        if (File.Exists(path))
        {
            using (StreamReader streamReader = File.OpenText(path))
            {
                string jsonString = streamReader.ReadToEnd();
                JsonUtility.FromJsonOverwrite(jsonString, gameState);
                //gameState.isWelcome = true;
                //gameState.onLevel = 1;
                //text = $"Last played: {gameState.lastPlayed}\n" +
                //        $"Last colleced coins: {gameState.coin}\n" +
                //        $"Last colleced gems: {gameState.gem}";
                gameState.coin = 0;
                gameState.live = 3;
            }
        }
        return text;
    }

    public void SaveToDisk()
    {
        gameState.lastPlayed = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        string jsonString = JsonUtility.ToJson(gameState);
        using (StreamWriter streamWriter = File.CreateText(path))
        {
            streamWriter.Write(jsonString);
        }
    }

}
