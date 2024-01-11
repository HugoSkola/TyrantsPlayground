using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpHeight;
    public float moveSpeed;
    Vector2 move;
    Rigidbody2D rb;
    bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement in the direction stated in code
        move = new Vector2(0, rb.velocity.y);
        if (Input.GetKey(KeyCode.A))
        {
            move += Vector2.left * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move += Vector2.right * moveSpeed;
        }
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            move += Vector2.up * jumpHeight;
            canJump = false;
        }

        rb.velocity = move;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}
