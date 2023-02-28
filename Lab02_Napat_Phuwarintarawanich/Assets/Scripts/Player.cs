using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject laser;
    [SerializeField] GameObject laserClone;

    [SerializeField] GameObject player;
    [SerializeField] GameObject alien;

    private float laserHeat;
    private const float TimeBetweenShots = 0.2f;

    public int PlayerLives { get; set; } = DataInformation.playerLife;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerLives <= 0)
        {
            Destroy(player);
            DataInformation.SetMessage("Alien");
            DataInformation.LoadMainMenu();
        }

        if (Input.GetKey(KeyCode.RightArrow) && gameObject.transform.position.x <= 8.2f)
        {
            transform.Translate(new Vector3(7 * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow) && gameObject.transform.position.x >= -8.2f)
        {
            transform.Translate(new Vector3(-7 * Time.deltaTime, 0, 0));
        }
        LaserToAlien();
    }

    void LaserToAlien()
    {
        if (laserHeat > 0)
        {
            laserHeat -= Time.deltaTime;
        } 
        if (Input.GetKeyDown(KeyCode.Space) && laserHeat <= 0)
        {
            laserClone = Instantiate(laser, new Vector3(player.transform.position.x, player.transform.position.y + 0.8f, 0), player.transform.rotation) as GameObject;
            laserHeat = TimeBetweenShots;
        }
    }
}
