using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Sounds.instance.PlayCheckpointSound();
            CheckpointSystem.instance.UpdateLastCheckpointPosition(this.transform.position);
            Destroy(this.gameObject);
        }
    }
}
