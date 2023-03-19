using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] Transform spawnPoint;

    GameTester gameTester;

    private void Start()
    {
        gameTester = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameTester>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        StartCoroutine(Wait(collider));
    }

    IEnumerator Wait(Collider2D collider)
    {
        yield return new WaitForSeconds(1);
        //Instantiate(ball, spawnPoint.position, spawnPoint.rotation);
        collider.transform.position = spawnPoint.position;
        collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameTester.DecreaseLive();
    }
}
