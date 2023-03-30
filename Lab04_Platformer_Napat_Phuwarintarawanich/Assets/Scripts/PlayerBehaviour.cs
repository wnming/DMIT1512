using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private int coinCount = 0;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && player.transform.position.x <= 7.8f)
        {
            transform.Translate(new Vector3(5 * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow) && player.transform.position.x >= -9.5f)
        {
            transform.Translate(new Vector3(-5 * Time.deltaTime, 0, 0));
        }
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
