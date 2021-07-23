using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    Transform playerPosition = null;

    void Update()
    {
        gameObject.transform.position = new Vector3(playerPosition.position.x, gameObject.transform.position.y, -10);
    }
}
