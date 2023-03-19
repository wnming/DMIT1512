using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] GameObject ball;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayArea")
        {
            Debug.Log("Hit");
            ball.transform.Translate(new Vector3(0, -4 * Time.deltaTime, 0));
        }
    }
}
