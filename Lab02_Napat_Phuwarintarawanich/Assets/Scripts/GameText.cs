using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI alienShips;
    [SerializeField] TextMeshProUGUI playerLife;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        alienShips.text = DataInformation.alienShipsText + DataInformation.numOfAliens;
        playerLife.text = DataInformation.playerLifeText + DataInformation.playerLife;
    }
}
