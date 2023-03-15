using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] Transform spawnPoint;

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Destroy(collider.gameObject);
        StartCoroutine(Wait(collider));
    }

    IEnumerator Wait(Collider2D collider)
    {
        yield return new WaitForSeconds(1);
        //Instantiate(ball, spawnPoint.position, spawnPoint.rotation);
        collider.transform.position = spawnPoint.position;
        collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
