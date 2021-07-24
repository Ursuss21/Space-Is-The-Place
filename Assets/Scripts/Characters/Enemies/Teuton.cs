using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teuton : MonoBehaviour
{
    [SerializeField]
    float distanceX = 0;
    [SerializeField]
    float speed = 0;

    Vector2 startPoint;
    Vector2 endPoint;

    bool moveToEnd = true;

    void Start()
    {
        startPoint = gameObject.transform.position;
        endPoint = new Vector2(gameObject.transform.position.x + distanceX, gameObject.transform.position.y);
    }

    void Update()
    {
        Move();
        CheckIfTargetReached();
        UpdateSpriteFacingDirection();
    }

    void Move()
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
        Vector2 teutonPos = transform.position;
        if (teutonPos == endPoint)
        {
            moveToEnd = false;
        }
        else if (teutonPos == startPoint)
        {
            moveToEnd = true;
        }
    }

    void UpdateSpriteFacingDirection()
    {
        if (moveToEnd)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.instance.OnDamageReceived();
        }
    }
}
