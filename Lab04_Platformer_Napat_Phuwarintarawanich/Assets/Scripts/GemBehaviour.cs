using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehaviour : MonoBehaviour, ICollectable
{
    private SpriteRenderer sprite;
    private Collider2D boundingBox;

    public int Value => 1;

    public CollectableType Type => CollectableType.Gem;

    public int Collect()
    {
        sprite.color = new Color(1, 1, 1, 0.2f);
        sprite.enabled = false;
        boundingBox.enabled = false;
        return Value;
    }

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
