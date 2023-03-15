using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameTester : MonoBehaviour
{
    [SerializeField] InputAction IncreaseScore;
    [SerializeField] InputAction DecreaseScore;
    [SerializeField] InputAction ResetScore;
    [SerializeField] InputAction SaveScore;
    [SerializeField] InputAction LoadScore;
    [SerializeField] InputAction TrySaveHighScore;

    GameState currentGameState;

    private void Start()
    {
        currentGameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
    }

    // Start is called before the first frame update
    private void OnEnable()
    {
        IncreaseScore.Enable();
        DecreaseScore.Enable();
        ResetScore.Enable();
        SaveScore.Enable();
        LoadScore.Enable();
        TrySaveHighScore.Enable();
    }

    // Update is called once per frame
    private void OnDisable()
    {
        IncreaseScore.Disable();
        DecreaseScore.Disable();
        ResetScore.Disable();
        SaveScore.Disable();
        LoadScore.Disable();
        TrySaveHighScore.Disable();
    }

    private void Update()
    {
        if (IncreaseScore.WasPressedThisFrame())
        {
            IncreaseCurrentScore();
        }
        if (DecreaseScore.WasPressedThisFrame())
        {
            DecreaseCurrentScore();
        }
        if (ResetScore.WasPressedThisFrame())
        {
            ResetCurrentScore();
        }
        if (SaveScore.WasPressedThisFrame())
        {
            SaveCurrentScore();
        }
        if (LoadScore.WasPressedThisFrame())
        {
            LoadCurrentScore();
        }
    }

    void IncreaseCurrentScore()
    {
        currentGameState.score += 1;
    }

    void DecreaseCurrentScore()
    {
        currentGameState.score -= 1;
    }

    void ResetCurrentScore()
    {
        currentGameState.score = 0;
    }

    void SaveCurrentScore()
    {
        FindObjectOfType<GameSaveManager>().SaveToDisk();
    }

    void LoadCurrentScore()
    {
        FindObjectOfType<GameSaveManager>().LoadFromDisk();
    }
}
