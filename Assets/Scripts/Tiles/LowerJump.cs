using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerJump : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player.instance.EnableLowerJump(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Player.instance.EnableLowerJump(false);
    }
}
