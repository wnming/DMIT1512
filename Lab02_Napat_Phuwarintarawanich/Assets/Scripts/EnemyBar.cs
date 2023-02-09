using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBar : MonoBehaviour
{
    Image RadialBar;
    [SerializeField]
    EnemyBehaviour enemy;
    // Start is called before the first frame update
    void Start()
    {
        if (!enemy) { Destroy(gameObject); }
        RadialBar = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateHPCircle()
    {
        RadialBar.fillAmount = enemy.GetHP();
    }
}
