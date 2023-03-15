using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    protected GameState gameState;
    string path = Path.Combine(Application.persistentDataPath, "Pinball_Highscore.txt");

    private void Start()
    {
        gameState = GameObject.FindObjectOfType<GameState>();
        //ui reference

    }

    private void Update()
    {
        scoreText.text = $"Score {gameState.score}";
    }

    public void LoadFromDisk()
    {
        if (File.Exists(path))
        {
            using (StreamReader reader = File.OpenText(path)) 
            { 
                string jsonString = reader.ReadToEnd();

                JsonUtility.FromJsonOverwrite(jsonString, gameState);
            }
        }
    }

    public void SaveToDisk()
    {
        string jsonString = JsonUtility.ToJson(gameState);
        using (StreamWriter writer = File.CreateText(path))
        {
            writer.Write(jsonString);
        }
        Debug.Log(path);
    }
}
