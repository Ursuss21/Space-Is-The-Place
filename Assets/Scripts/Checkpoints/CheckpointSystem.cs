using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    Vector2 lastCheckpointPosition;

    public static CheckpointSystem instance { get; set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        lastCheckpointPosition = new Vector2(0.0f, 0.0f);
    }

    public void UpdateLastCheckpointPosition(Vector2 newPos)
    {
        lastCheckpointPosition = newPos;
    }

    public Vector2 GetLastCheckpointPosition()
    {
        return lastCheckpointPosition;
    }

    public void EnableEndScreen()
    {

    }
}
