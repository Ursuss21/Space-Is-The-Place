using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Sounds.instance.PlayCollectSound();
            Player.instance.OnCollectedOnion();
            Destroy(this.gameObject);
        }
    }
}
