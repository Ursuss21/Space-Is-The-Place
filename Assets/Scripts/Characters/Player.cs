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

    Vector2 forceFieldVector;
    bool forceFieldIsActive = false;

    int lives = 3;
    int onions = 0;

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
        forceFieldVector = new Vector2(0.0f, 0.0f);
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

        HandleForceField();
        UpdateAnimation(Mathf.Abs(x));
        UpdateSpriteFacingDirection(x);
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

    void HandleForceField()
    {
        if (forceFieldIsActive)
        {
            rb.velocity += forceFieldVector * speed;
        }
    }

    void UpdateAnimation(float x)
    {
        GetComponent<Animator>().SetFloat("isMoving", x);
    }

    void UpdateSpriteFacingDirection(float direction)
    {
        if(direction < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(direction > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
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

    public void ChangeForceFieldDirection(Vector2 newVector, bool isActive)
    {
        forceFieldVector = newVector;
        forceFieldIsActive = isActive;
    }

    public void OnDamageReceived()
    {
        HealthHUD.instance.DecrementHealth();
        if (lives > 1)
        {
            --lives;
            this.transform.position = CheckpointSystem.instance.GetLastCheckpointPosition();
        }
        else
        {
            EndScreen.instance.EnableEndScreen();
            this.enabled = false;
        }
    }

    public int GetLives()
    {
        return lives;
    }

    public void OnCollectedHealth()
    {
        if(lives < 3)
        {
            ++lives;
            HealthHUD.instance.IncrementHealth();
        }
    }

    public void OnCollectedOnion()
    {
        ++onions;
        OnionHUD.instance.IncreaseOnions();
    }
    
    public int GetOnions()
    {
        return onions;
    }
}
