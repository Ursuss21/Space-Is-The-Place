using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    float distanceX = 0;
    [SerializeField]
    float distanceY = 0;
    [SerializeField]
    float speed = 0;

    Vector2 startPoint;
    Vector2 endPoint;

    bool moveToEnd = true;

    void Start()
    {
        startPoint = gameObject.transform.position;
        endPoint = new Vector2(gameObject.transform.position.x + distanceX, gameObject.transform.position.y + distanceY);
    }

    void Update()
    {
        MovePlatform();
        CheckIfTargetReached();
    }

    void MovePlatform()
    {
        if (moveToEnd)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPoint, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startPoint, speed * Time.deltaTime);
        }
    }

    void CheckIfTargetReached()
    {
        Vector2 platformPos = transform.position;
        if(platformPos == endPoint)
        {
            moveToEnd = false;
        }
        else if(platformPos == startPoint)
        {
            moveToEnd = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
