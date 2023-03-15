using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    [SerializeField] GameObject ball;
    [SerializeField] Transform spawnPoint;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(collider.gameObject);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        Instantiate(ball, spawnPoint.position, spawnPoint.rotation);
    }
}
