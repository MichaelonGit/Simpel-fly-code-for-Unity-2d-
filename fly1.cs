using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly1: MonoBehaviour
{
    public float speed = 5f; // The speed at which the character moves in space
    public float gravity = -9.81f; // The strength of gravity when the character is in normal mode
    public bool suspended = false; // Determines whether the character is suspended in space or not

    private Rigidbody2D rb; // A reference to the character's Rigidbody2D component

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // If the "E" key is pressed and the character is not already suspended in space...
        if (Input.GetKeyDown(KeyCode.E) && !suspended)
        {
            // ...suspend the character in space
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            suspended = true;
        }
        // If the "E" key is pressed and the character is suspended in space...
        else if (Input.GetKeyDown(KeyCode.E) && suspended)
        {
            // ...revert the character back to normal
            rb.gravityScale = 1;
            suspended = false;
        }

        // If the character is suspended in space...
        if (suspended)
        {
            // ...use the "A" and "D" keys to move the character left and right
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector2 movement = new Vector2(horizontalInput, 0) * speed;
            rb.velocity = movement;

            // ...use the "Space" and "Shift" keys to move the character up and down
            if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity += Vector2.up * speed;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity += Vector2.down * speed;
            }
        }
    }
}
