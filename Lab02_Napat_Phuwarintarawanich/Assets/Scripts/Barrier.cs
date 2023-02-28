using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] GameObject barrier;
    public int barrierHit = 0;

    private int MaxTimeHit = 40;
    private int MedianTimeHit = 30;
    private int MinTimeHit = 20;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (barrierHit > MinTimeHit)
        {
            barrier.GetComponent<SpriteRenderer>().color = new Color(255, 140, 0, 255);
        }
        if (barrierHit > MedianTimeHit)
        {
            barrier.GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (barrierHit > MaxTimeHit)
        {
            Destroy(barrier);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "alien")
        {
            Destroy(barrier);
        }
        if (collision.gameObject.tag == "alienLaser")
        {
            barrierHit++;
        }
    }
}
