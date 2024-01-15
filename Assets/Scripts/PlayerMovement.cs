using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask ground;
    public float jumpHeight;
    public float moveSpeed;
    Vector2 move;
    Rigidbody2D rb;
    public bool canJump = true;
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((ground.value & (1 << collision.gameObject.layer)) != 0)
        {
            canJump = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((ground.value & (1 << collision.gameObject.layer)) != 0)
        {
            canJump = false;
        }
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
        }
        if (rb.velocity.x > 0.5f && canJump || rb.velocity.x < -0.5f && canJump)
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
        else if (canJump)
        {

        }
        else
        {
            walkFrame = 12;
            if (walkCountDown < 0 && walkFrame < 16)
            {
                walkCountDown = walkCountDownReset;
                walkFrame++;
            }
            else
            {
                walkCountDown -= Time.deltaTime;
            }
            
            
        }

        player.sprite = walkFrameSprite[walkFrame];

        rb.velocity = move;
    }
}
