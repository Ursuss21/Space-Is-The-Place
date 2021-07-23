using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }

    [SerializeField]
    Direction fieldDirection = Direction.Up;

    void ManageForceField()
    {
        switch (fieldDirection)
        {
            case Direction.Up:
                Player.instance.ChangeForceFieldDirection(new Vector2(0.0f, 0.01f), true);
                break;
            case Direction.Right:
                Player.instance.ChangeForceFieldDirection(new Vector2(0.5f, 0.0f), true);
                break;
            case Direction.Down:
                Player.instance.ChangeForceFieldDirection(new Vector2(0.0f, -0.01f), true);
                break;
            case Direction.Left:
                Player.instance.ChangeForceFieldDirection(new Vector2(-0.5f, 0.0f), true);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ManageForceField();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ManageForceField();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.instance.ChangeForceFieldDirection(new Vector2(0.0f, 0.0f), false);
        }
    }
}
