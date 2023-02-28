using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtonText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buttonText;
    public bool IsPlayerWins {get; set;}
    public bool IsChangeText { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        buttonText.text = DataInformation.buttonText;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
