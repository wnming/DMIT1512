using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings;

public class BallBehaviourScript : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Mouse.current.leftButton.wasPressedThisFrame)
        //{
        //    SetBallPosition(Camera.main.ScreenToWorldPoint(Mouse.current.position.value));
        //}
    }

    public void SetBallPosition(Vector2 position)
    {
        rb.transform.position = position;
        rb.velocity = Vector2.zero;
    }

}
