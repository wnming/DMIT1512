using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private int coinCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.GetComponent<ICollectable>() != null)
        {
            ICollectable collectable = collision.GetComponent<ICollectable>();
            switch (collectable.Type)
            {
                case CollectableType.None:
                    break;
                case CollectableType.Money:
                    coinCount += collectable.Collect();
                    break;
                case CollectableType.Key:
                    break;
                case CollectableType.Gem:
                    collectable.Collect();
                    break;
                default:
                    break;
            }
        }
    }
}
