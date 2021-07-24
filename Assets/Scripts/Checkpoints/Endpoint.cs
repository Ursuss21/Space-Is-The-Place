using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WinScreen.instance.EnableWinScreen();
        Destroy(this.gameObject);
    }
}
