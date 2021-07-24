using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    Transform playerPosition = null;

    [SerializeField]
    float levelWidth = 0.0f;

    void Update()
    {
        if (playerPosition.position.x >= 0.0f && playerPosition.position.x <= levelWidth)
        {
            gameObject.transform.position = new Vector3(playerPosition.position.x, gameObject.transform.position.y, -10.0f);
        }
        else if (playerPosition.position.x < 0.0f)
        {
            gameObject.transform.position = new Vector3(0.0f, 0.0f, -10.0f);
        }
        else if (playerPosition.position.x > levelWidth)
        {
            gameObject.transform.position = new Vector3(levelWidth, 0.0f, -10.0f);
        }
    }
}
