using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    [SerializeField] BossBehaviour boss;
    Slider hpBar;
    // Start is called before the first frame update
    void Start()
    {
        if (!boss) { Destroy(gameObject); }
        boss = GetComponent<BossBehaviour>();
        hpBar = GetComponent<Slider>();
        hpBar.maxValue = boss.GetMaxHP();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }

    void UpdateHealth()
    {
        hpBar.value = boss.GetCurrentHP();
    }
}
