using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlungerScript : MonoBehaviour
{
    [SerializeField] SpringJoint2D plunger;
    [SerializeField] GameObject ball;

    public void Pull(float amount)
    {
        plunger.distance = amount * -300f;
        plunger.attachedRigidbody.AddForce(Vector2.down * amount * 500);
    }
}
