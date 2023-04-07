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
        path = Path.Combine(Application.persistentDataPath, "CollectedCoins.txt");
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

    public void LoadFromDisk()
    {
        if (File.Exists(path))
        {
            using (StreamReader streamReader = File.OpenText(path))
            {
                string jsonString = streamReader.ReadToEnd();
                JsonUtility.FromJsonOverwrite(jsonString, gameState);
                //gameState.score = 0;
                gameState.coin = 0;
                gameState.live = 3;
            }
        }
    }

    public void SaveToDisk()
    {
        string jsonString = JsonUtility.ToJson(gameState);
        using (StreamWriter streamWriter = File.CreateText(path))
        {
            streamWriter.Write(jsonString);
        }
    }

}
