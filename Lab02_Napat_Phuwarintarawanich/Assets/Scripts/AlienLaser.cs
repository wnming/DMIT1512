using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienLaser : MonoBehaviour
{
    [SerializeField] GameObject alienLaser;
    GameObject playerObject;
    Player player = new Player();

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindWithTag("player");
        player = playerObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -4 * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Destroy(alienLaser);
            player.PlayerLives -= 1;
            DataInformation.playerLife = player.PlayerLives;
        }
        if (collision.gameObject.tag == "Finish" || collision.gameObject.tag == "barrier")
        {
            Destroy(alienLaser);
        }
    }
}
