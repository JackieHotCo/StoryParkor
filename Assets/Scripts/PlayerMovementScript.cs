using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    // The speed in which the character moves
    public float speed;
    // The vitual horizontal axis of the character
    private float move;

    // the rigid body of the character
    public Rigidbody2D rb;

    // the collider for the character
    public BoxCollider2D bc;

    // Checks whether the player is touching the ground or not
    public bool grounded = false;

    // Update is called once per frame
    void Update()
    {
        // detects the input of the charcter moving left and right
        move = Input.GetAxisRaw("Horizontal");

        // Moves the gameObject left and right and sprinting
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Makes the player jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector2.up * 500);
        }

        // Flips the image when the character changes direction
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.transform.localScale = new Vector3(1, 1, 1);
        }

        // Crouching
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            bc.size = new Vector2(4.8f, 5);
            bc.offset = new Vector2(0.3f, -2);
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            bc.size = new Vector2(4.8f, 9.5f);
            bc.offset = new Vector2(0.3f, 0);
        }
    }

    

    // Detects when the player comes in contact with the ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            grounded = true;
        }
    }

    // Detects when the player has lost contact with the ground
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            grounded = false;
        }
    }
}
