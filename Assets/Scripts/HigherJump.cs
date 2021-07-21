using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HigherJump : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement.instance.EnableHigherJump(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        PlayerMovement.instance.EnableHigherJump(false);
    }
}