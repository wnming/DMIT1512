using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitBehaviour : MonoBehaviour
{
    [SerializeField] Transform ballSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(WaitToRespawn(collision));
    }

    IEnumerator WaitToRespawn(Collider2D collider)
    {
        yield return new WaitForSeconds(2);
        collider.attachedRigidbody.transform.position = ballSpawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
