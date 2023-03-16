using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [SerializeField] GameObject background;

    void Start()
    {
        Instantiate(background);
    }
}
