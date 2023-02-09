using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Text = TMPro.TMP_Text;

public class SpaceCounter : MonoBehaviour
{
    [SerializeField] GameObject PlayerPrefab;
    PlayerBehaviour playerScript;
    Text spaceText;
    // Start is called before the first frame update
    void Start()
    {
        GameObject p = Instantiate(PlayerPrefab);
        playerScript = p.GetComponent<PlayerBehaviour>();
        //playerScript = PlayerPrefab.GetComponent<PlayerBehaviour>();
        spaceText = GetComponent<Text>();
        //playerScript = GameObject.FindObjectOfType<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerScript){ return; }
        spaceText.text = $"Space has been pressed {playerScript.Count} times"; 
    }
}
