using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Alien : MonoBehaviour
{
    float timer = 0;
    float moveTime = 0.5f;
    int movement = 0;

    public GameObject alienLaser;
    public GameObject alienLaserClone;
    public GameObject alien;

    public GameObject player;
    public GameObject barrier;

    private int alienMove = DataInformation.alienMove;
    private float speed = DataInformation.alienSpeed;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (movement == alienMove)
        {
            transform.Translate(new Vector3(0, -1, 0));
            movement = -1;
            speed = -speed;
            timer = 0;
        }

        timer += Time.deltaTime;

        if (timer > moveTime && movement != alienMove)
        {
            transform.Translate(new Vector3(speed, 0, 0));
            timer = 0;
            movement++;
        }

        lazerToPlayer();
    }

    void lazerToPlayer()
    {
        if (Random.Range(0f, 1000f) < 1)
        {
            alienLaserClone = Instantiate(alienLaser, new Vector3(alien.transform.position.x, alien.transform.position.y - 0.2f, 0), alien.transform.rotation) as GameObject;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Destroy(alien);
            DataInformation.SetMessage("Alien");
            DataInformation.LoadMainMenu();
        }
        if (collision.gameObject.tag == "Finish")
        {
            DataInformation.SetMessage("Alien");
            DataInformation.LoadMainMenu();
        }
    }
}
