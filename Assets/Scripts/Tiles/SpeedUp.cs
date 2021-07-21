using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player.instance.EnableSpeedUp(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Player.instance.EnableSpeedUp(false);
    }
}
