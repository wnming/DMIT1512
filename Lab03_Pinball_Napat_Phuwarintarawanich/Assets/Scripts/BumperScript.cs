using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SocialPlatforms.Impl;

public class BumperScript : MonoBehaviour
{
    [SerializeField] GameObject bumper;
    [SerializeField] GameObject ball;
    [SerializeField] Rigidbody2D m_Rigidbody;

    public float moveSpeed = 0.4f;
    private bool collide = false;

    GameTester gameTester;


    void Start()
    {
        gameTester = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameTester>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
        collide = false;
    }

    void FixedUpdate()
    {
        if (collide)
        {
            m_Rigidbody.AddForce(Vector3.up * 300, ForceMode2D.Force);
            collide = false;
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            collide = true;
            gameTester.IncreaseCurrentScore();
            //add force
            //m_Rigidbody.velocity = Vector3.up * m_Thrust;
            //m_Rigidbody.AddForce(Vector3.up * 300, ForceMode2D.Force);
            //m_Rigidbody.AddForce(Vector3.forward * moveSpeed);
            // m_Rigidbody.AddForce(transform.up * m_Thrust);
            //ball.GetComponent<Rigidbody2D>().AddRelativeForce(Vector3.forward * 100, ForceMode2D.Impulse);
            //.GetComponent<Rigidbody2D>().AddForce(ball.transform.forward);
            //change bumper's color for 2 sec
            StartCoroutine(ChangeColor());
        }
    }

    private IEnumerator ChangeColor()
    {
        bumper.GetComponent<Renderer>().material.color = new Color(0, 204, 102);
        yield return new WaitForSeconds(0.2f);
        bumper.GetComponent<Renderer>().material.color = Color.white;
    }
}
