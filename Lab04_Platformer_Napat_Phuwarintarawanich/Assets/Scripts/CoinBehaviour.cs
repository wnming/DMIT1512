using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour, ICollectable
{
    private SpriteRenderer sprite;
    private Collider2D boundingBox;

    public int Value => 1;
    public int Collect()
    {
        sprite.enabled = false;
        boundingBox.enabled = false;
        return Value;
    }

    public CollectableType Type => CollectableType.Money;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        boundingBox = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
