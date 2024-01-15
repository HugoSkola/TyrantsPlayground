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
    public int walkFrame;
    public Sprite[] walkFrameSprite;
    public SpriteRenderer player;
    public AudioClip walkingSoundClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        walkCountDown = walkCountDownReset;
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
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
            walkingSound();
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector2(-1, 1);
            move += Vector2.right * moveSpeed;
            walkingSound();
        }
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            move += Vector2.up * jumpHeight;
        }
        if (rb.velocity.x > 0.5f && canJump && walkFrame < 12 || rb.velocity.x < -0.5f && canJump && walkFrame < 12)
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
            else if (walkFrame < 12)
            {
                walkFrame = 0;
            }
        }
        else if (canJump && walkFrame < 12)
        {
            walkFrame = 0;
        }
        else
        {
            if (walkFrame < 12)
            {
                walkFrame = 12;
            }
            else if (walkCountDown < 0 && walkFrame < 16 && !canJump)
            {
                walkCountDown = walkCountDownReset;
                walkFrame++;
            }
            else if (walkCountDown < 0 && canJump)
            {
                if (walkFrame > 11)
                {
                    walkFrame--;
                }
                walkCountDown = walkCountDownReset;
            }
            else
            {
                walkCountDown -= Time.deltaTime;
            }
            
            
        }

        player.sprite = walkFrameSprite[walkFrame];

        rb.velocity = move;
    }
    void walkingSound()
    {
        if (walkingSoundClip != null && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(walkingSoundClip);
        }
    }
}
