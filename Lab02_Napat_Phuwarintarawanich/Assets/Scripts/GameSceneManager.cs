using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        DataInformation.buttonText = "Play Again";
        DataInformation.messageColor = Color.red;
    }

    public void LoadLevelOne()
    {
        DataInformation.playerLife = DataInformation.InitialPlayerLife;
        DataInformation.numOfAliens = DataInformation.level1NumOfAliens;
        DataInformation.alienSpeed = DataInformation.level1Speed;
        DataInformation.alienMove = DataInformation.level1Move;
        DataInformation.onLevel = 1;
        SceneManager.LoadScene(1);
    }

    public void LoadLevelTwo()
    {
        DataInformation.numOfAliens = DataInformation.level2NumOfAliens;
        DataInformation.alienSpeed = DataInformation.level2Speed;
        DataInformation.alienMove = DataInformation.level2Move;
        DataInformation.onLevel = 2;
        SceneManager.LoadScene(2);
    }
}
