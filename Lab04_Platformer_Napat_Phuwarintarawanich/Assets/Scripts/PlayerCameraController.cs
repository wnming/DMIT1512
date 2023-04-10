using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;

    void Update()
    {
        transform.position = player.transform is not null ? player.transform.position + offset : new Vector3(0, 0, 0);
    }
}
