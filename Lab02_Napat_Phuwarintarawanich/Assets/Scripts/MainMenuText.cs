using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI message;
    [SerializeField] TextMeshProUGUI title;

    // Start is called before the first frame update
    void Start()
    {
        title.text = DataInformation.title;
        message.text = DataInformation.message;
        message.color = DataInformation.messageColor;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
