using UnityEngine;

public class Script : MonoBehaviour
{
    Rigidbody2D rb;
    float moveSpeed = 3;
    float jumpPower = 5;
    bool isGrounded = true;
    bool jumped = false;
    GameObject balloon;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        balloon = GameObject.Find("Balloon");
        balloon.GetComponent<SpriteRenderer>().enabled = false;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && (!jumped || isGrounded))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            if (!isGrounded && !jumped)
            {
                jumped = true;
            }
        }
        if (Input.GetKey(KeyCode.X) && !isGrounded)
        {
            balloon.GetComponent<SpriteRenderer>().enabled = true;
            rb.gravityScale = 0.3f;
        }
        else
        {
            balloon.GetComponent<SpriteRenderer>().enabled = false;
            rb.gravityScale = 1;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        jumped = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        jumped = false;
    }
}
