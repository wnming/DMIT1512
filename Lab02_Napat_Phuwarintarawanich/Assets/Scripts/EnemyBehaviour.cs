using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    int currentHP;
    [SerializeField]
    int maxHP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.numpad2Key.wasPressedThisFrame)
        {
            currentHP -= 1;
        }
    }

    public float GetHP()
    {
        return currentHP / maxHP;
    }
}
