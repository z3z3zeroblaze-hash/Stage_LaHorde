using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 8f;
    public float climbSpeed = 4f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isOnLadder;
    private Transform spawnPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnPoint = GameObject.Find("SpawnPoint").transform;
    }

    void Update()
    {
        float move = 0;

        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
            move = -1;

        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
            move = 1;

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (isOnLadder)
        {
            float climb = 0;

            if (Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed)
                climb = 1;

            if (Keyboard.current.downArrowKey.isPressed || Keyboard.current.sKey.isPressed)
                climb = -1;

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, climb * climbSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = true;
            rb.gravityScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = false;
            rb.gravityScale = 1;
        }
    }
    public void RetourAuDepart()
    {
        transform.position = spawnPoint.position;
        rb.linearVelocity = Vector2.zero;
    }
}