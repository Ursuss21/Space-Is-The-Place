using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float speed;
    [SerializeField]
    float jumpForce;

    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    [SerializeField]
    float fallMultiplier = 2.5f;
    [SerializeField]
    float lowJumpMultiplier = 2f;

    float higherJumpMultiplier = 1.5f;
    float lowerJumpMultiplier = 0.5f;
    float speedMultiplier = 1.5f;

    [SerializeField]
    float rememberGroundedFor;
    float lastTimeGrounded;

    int lives = 3;

    public static Player instance { get; set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
        BetterJump();
        CheckIfGrounded();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }
    
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void BetterJump()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if(colliders != null)
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

    public void EnableHigherJump(bool enabled)
    {
        if (enabled)
        {
            jumpForce *= higherJumpMultiplier;
        }
        else
        {
            jumpForce /= higherJumpMultiplier;
        }
    }

    public void EnableLowerJump(bool enabled)
    {
        if (enabled)
        {
            jumpForce *= lowerJumpMultiplier;
        }
        else
        {
            jumpForce /= lowerJumpMultiplier;
        }
    }

    public void EnableSpeedUp(bool enabled)
    {
        if (enabled)
        {
            speed *= speedMultiplier;
        }
        else
        {
            speed /= speedMultiplier;
        }
    }

    public void OnDamageReceived()
    {
        if(lives > 0)
        {
            --lives;
            this.transform.position = CheckpointSystem.instance.GetLastCheckpointPosition();
            Health.instance.DecrementHealth();
            Debug.Log("Ouch!");
        }
        else
        {
            Debug.Log("Game over!");
        }
    }

    public int GetLives()
    {
        return lives;
    }
}
