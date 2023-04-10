using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] AudioSource jumpAudio;
    [SerializeField] AudioSource coinAudio;
    [SerializeField] AudioSource heartAudio;
    [SerializeField] AudioSource keyAudio;
    [SerializeField] AudioSource trapAudio;
    [SerializeField] AudioSource gemAudio;

    private PostureState postureState;

    GameControl gameControl;
    void Start()
    {
        gameControl = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameControl>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(gameControl.currentGameState.onLevel == 1)
        {
            gameControl.ResetLevel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(5 * Time.deltaTime, 0, 0));
            spriteRenderer.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-5 * Time.deltaTime, 0, 0));
            spriteRenderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.UpArrow) && player.transform.position.y <= 4.5f)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                jumpAudio.Play();
            }
            transform.Translate(new Vector3(0, 10 * Time.deltaTime, 0));
        }
        AnimationPosture();
    }

    void AnimationPosture()
    {
        float axisRaw = Input.GetAxisRaw("Horizontal");
        if (axisRaw > 0f)
        {
            postureState = PostureState.running;
        }
        else
        {
            if (axisRaw < 0f)
            {
                postureState = PostureState.running;
            }
            else
            {
                postureState = PostureState.idle;
            }
        }
        animator.SetInteger("posture", (int)postureState);
    }

    private IEnumerator ChangeColor()
    {
        player.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        player.GetComponent<Renderer>().material.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "finishLevel")
        {
            gameControl.CheckToAnotherLevel();
        }
        if (collision != null && collision.gameObject.tag == "deathTrap")
        {
            animator.SetTrigger("playerDeath");
            gameControl.Die();
        }
        if (collision != null && collision.gameObject.tag == "trap")
        {
            trapAudio.Play();
            StartCoroutine(ChangeColor());
            gameControl.DecreaseLive();
        }
        if(collision != null && collision.GetComponent<ICollectable>() != null)
        {
            ICollectable collectable = collision.GetComponent<ICollectable>();
            switch (collectable.Type)
            {
                case CollectableType.None:
                    break;
                case CollectableType.Money:
                    coinAudio.Play();
                    gameControl.currentGameState.coin += collectable.Collect();
                    break;
                case CollectableType.Key:
                    keyAudio.Play();
                    gameControl.CollectKey();
                    collectable.Collect();
                    break;
                case CollectableType.Heart:
                    heartAudio.Play();
                    collectable.Collect();
                    gameControl.IncreaseLive();
                    break;
                case CollectableType.Gem:
                    gemAudio.Play();
                    gameControl.currentGameState.gem += collectable.Collect();
                    break;
                default:
                    break;
            }
        }
    }

    private enum PostureState
    {
        idle,
        running
    }
}
