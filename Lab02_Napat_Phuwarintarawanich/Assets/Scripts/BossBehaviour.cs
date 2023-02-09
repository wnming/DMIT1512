using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BossBehaviour : MonoBehaviour
{
    [SerializeField]
    //BossBar healthBar;
    int MaxHealth;
    [SerializeField]
    int CurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.numpad1Key.wasPressedThisFrame)
        {
            CurrentHealth -= 1;
        }
    }

    public int GetMaxHP()
    {
        return MaxHealth;
    }

    public int GetCurrentHP()
    {
        return CurrentHealth;
    }
}
