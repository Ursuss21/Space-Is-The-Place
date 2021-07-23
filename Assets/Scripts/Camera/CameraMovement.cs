using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    Transform playerPosition = null;

    void Update()
    {
        if(playerPosition.position.x >= 0 && playerPosition.position.x <= 45)
        {
            gameObject.transform.position = new Vector3(playerPosition.position.x, gameObject.transform.position.y, -10);
        }
    }
}
