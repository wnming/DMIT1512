using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI livesText;
    protected GameState gameState;
    private string path;

    private void Awake()
    {
        path = Path.Combine(Application.persistentDataPath, "PinballHighscore.txt");
    }
    private void Start()
    {
        gameState = GameObject.FindObjectOfType<GameState>();
        LoadFromDisk();
    }

    private void Update()
    {
        scoreText.text = $"Score: {gameState.score}";
        livesText.text = $"Live: {gameState.live}";
        highScoreText.text = $"High Score: {gameState.highScore}";
    }

    public void LoadFromDisk()
    {
        if (File.Exists(path))
        {
            using (StreamReader streamReader = File.OpenText(path))
            {
                string jsonString = streamReader.ReadToEnd();
                JsonUtility.FromJsonOverwrite(jsonString, gameState);
                gameState.score = 0;
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
