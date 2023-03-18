using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlungerScript : MonoBehaviour
{
    [SerializeField] SpringJoint2D plunger;
    [SerializeField] GameObject ball;
    //[SerializeField] GameObject ball;
    //private float distance = 50;
    //private float speed = 1;
    //private float power = 2000;

    //private bool ready = false;
    //private bool shoot = false;

    //private float move = 0;

    //void Update()
    //{
    //    if (Keyboard.current.enterKey.isPressed)
    //    {
    //        if (move < distance)
    //        {
    //            transform.Translate(0, 0, -speed * Time.deltaTime);
    //            move += speed * Time.deltaTime;
    //            shoot = true;
    //        }
    //    }
    //    else
    //    {
    //        if(move > 0)
    //        {
    //            if(ready && shoot)
    //            {
    //                ball.transform.TransformDirection(Vector3.forward * 10);
    //                ball.GetComponent<Rigidbody>().AddForce(0, 0, move * power);
    //                shoot = false;
    //                ready = false;
    //            }
    //            transform.Translate(0, 0, 20 * Time.deltaTime);
    //            move -= 20 * Time.deltaTime;
    //        }
    //    }

    //    if (move <= 0)
    //    {
    //        shoot = false;
    //        move = 0;
    //    }
    //}

    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "Ball")
    //    {
    //        ready = true;
    //    }
    //}
    public void Update()
    {
        Pull(0.5f);
        Release(0.5f);
    }

    void FixedUpdate()
    {
        //var rb = plunger.GetComponent<Rigidbody2D>();
        ////Vector3 force = rb.transform.position;

        //var forceToApply = rb.transform.position;
        //rb.AddForce(forceToApply);
    }

    public void Pull(float amount)
    {
        plunger.distance = amount * -5f;
        plunger.attachedRigidbody.AddForce(Vector2.down * amount * 16);
    }

    public void Release(float amount)
    {
        plunger.distance = amount * 5f;
        plunger.attachedRigidbody.AddForce(Vector2.up * amount * 5);

        //GetComponent<Rigidbody2D>().AddForce(ball.transform.position - transform.position * 25f * Time.deltaTime);
        //var rb = ball.GetComponent<Rigidbody2D>();
        //rb = new Vector2(3, 3);
        //rb.AddForce(rb.velocity);
    }
}
