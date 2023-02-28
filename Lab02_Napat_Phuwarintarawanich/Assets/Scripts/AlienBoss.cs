using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBoss : MonoBehaviour
{
    float timer = 0;
    float moveTime = 0.5f;
    int movement = 0;

    public GameObject bossLaser;
    public GameObject bossLaserClone;
    public GameObject boss;

    public GameObject player;
    public GameObject barrier;

    private int bossMove = 7;

    private float speed = -0.6f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (movement == bossMove)
        {
            //transform.Translate(new Vector3(0, 0, 0));
            speed = -speed;
            movement = -1;
            timer = 0;
        }

        timer += Time.deltaTime;

        if (timer > moveTime && movement != bossMove)
        {
            transform.Translate(new Vector3(speed, 0, 0));
            timer = 0;
            movement++;
        }

        lazerToPlayer();
    }

    void lazerToPlayer()
    {
        if (Random.Range(0f, 800f) < 1)
        {
            bossLaserClone = Instantiate(bossLaser, new Vector3(boss.transform.position.x, boss.transform.position.y - 0.2f, 0), boss.transform.rotation) as GameObject;
        }
    }
}
