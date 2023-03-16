using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerInput playerInput;
    Vector2 moveVector;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.AddForce(4.5F * moveVector * Vector2.right);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.action.WasPerformedThisFrame())
        {
            rb.AddForce(8f * Vector2.up, ForceMode2D.Impulse);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.action.WasPerformedThisFrame())
        {
            moveVector = context.ReadValue<Vector2>();
        }
    }
}
