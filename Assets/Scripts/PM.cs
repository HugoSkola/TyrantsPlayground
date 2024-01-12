using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM : MonoBehaviour
{
    public float jumpHeight;
    public float moveSpeed;
    Vector2 move;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(0, rb.velocity.y);
        if (Input.GetKey(KeyCode.A))
        {
            move += Vector2.left * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move += Vector2.right * moveSpeed;
        }
        if (rb.velocity.y == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            move += Vector2.up * jumpHeight;
        }

        rb.velocity = move;
    }
}
