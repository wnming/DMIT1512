using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] GameObject laser;

    private bool isCollision = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 5 * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "alien" || collision.gameObject.tag == "boss") && !isCollision)
        {
            isCollision = true;
            DataInformation.numOfAliens -= 1;
            Destroy(collision.gameObject);
            Destroy(laser);
            if (DataInformation.numOfAliens <= 0)
            {
                if (DataInformation.onLevel == 1)
                {
                    DataInformation.LoadLevelTwo();
                }
                else
                {
                    DataInformation.playerScore += 1;
                    DataInformation.SetMessage("Player");
                    DataInformation.LoadMainMenu();
                }
            }
        }
        if (collision.gameObject.tag == "Finish" || collision.gameObject.tag == "barrier")
        {
            Destroy(laser);
        }
        isCollision = false;
    }
}
