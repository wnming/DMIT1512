using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] Transform spawnPoint;

    GameControl GameControl;

    private void Start()
    {
        GameControl = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameControl>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        StartCoroutine(Wait(collider));
    }

    IEnumerator Wait(Collider2D collider)
    {
        yield return new WaitForSeconds(1);
        collider.transform.position = spawnPoint.position;
        collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameControl.DecreaseLive();
    }
}
