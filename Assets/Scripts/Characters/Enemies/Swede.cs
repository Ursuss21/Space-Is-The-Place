using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swede : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float jumpForce;

    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    [SerializeField]
    float rememberGroundedFor;
    float lastTimeGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Jump();
        CheckIfGrounded();
    }

    void Jump()
    {
        if (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (colliders != null)
        {
            isGrounded = true;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.instance.OnDamageReceived();
        }
    }
}
