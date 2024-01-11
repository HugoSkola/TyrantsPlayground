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
    public float walkCountDown;
    public float walkCountDownReset;
    public int maxWalkFrame;
    int walkFrame;
    public Sprite[] walkFrameSprite;
    public SpriteRenderer player;
    // Start is called before the first frame update
    void Start()
    {
        walkCountDown = walkCountDownReset;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement in the direction stated in code
        move = new Vector2(0, rb.velocity.y);
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector2(1, 1);
            move += Vector2.left * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector2(-1, 1);
            move += Vector2.right * moveSpeed;
        }
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            move += Vector2.up * jumpHeight;
            canJump = false;
        }
        if (rb.velocity.x != 0 && rb.velocity.y == 0)
        {
            if (walkCountDown > 0)
            {
                walkCountDown -= Time.deltaTime;
            }
            else if (walkCountDown < 0 && walkFrame < maxWalkFrame)
            {
                walkCountDown = walkCountDownReset;
                walkFrame++;
            }
            else
            {
                walkFrame = 0;
            }
        }
        else
        {
            walkCountDown = walkCountDownReset;
            walkFrame = 0;
        }

        player.sprite = walkFrameSprite[walkFrame];

        rb.velocity = move;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}
