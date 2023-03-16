using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerScript : MonoBehaviour
{
    [SerializeField] SpringJoint2D plunger;
    public void Pull(float amount)
    {
        plunger.distance = amount * -12f;
        plunger.attachedRigidbody.AddForce(Vector2.down * amount * 16);
    }
}
