using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.instance.OnCollectedOnion();
        Destroy(this.gameObject);
    }
}
