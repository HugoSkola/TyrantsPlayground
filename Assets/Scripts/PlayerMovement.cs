using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask ground;
    public float jumpHeight;
    public float moveSpeed;
    public float forceMagnitude = 10f;
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
    public AudioClip JumpSoundClip;
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
    void FixedUpdate()
    {
     
        rb.AddForce(transform.forward * forceMagnitude, ForceMode2D.Force);
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
            if (canJump)
            {
                walkingSound();
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector2(-1, 1);
            move += Vector2.right * moveSpeed;
            if (canJump)
            {
                walkingSound();
            }
        }
 
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            move += Vector2.up * jumpHeight;
            jumpingSound();
        }

        rb.velocity = move;

        // When player is jumping
        if (!canJump)
        {
            if (walkFrame > 16 || walkFrame < 12)
            {
                walkFrame = 12;
            }

            if (walkCountDown < 0 && (walkFrame < 16 || walkFrame > 16))
            {
                walkCountDown = walkCountDownReset;
                walkFrame++;
                Debug.Log("walkframe increase");
            }
            else
            {
                walkCountDown -= Time.deltaTime;
            }




        }
        else if (canJump && (walkFrame > 11 && walkFrame < 17))
        {
            if (walkCountDown < 0 && (walkFrame > 11 && walkFrame < 17) && canJump)
            {
                walkFrame--;
                Debug.Log("walkframe decrease");
                walkCountDown = walkCountDownReset;
            }
            else
            {
                walkCountDown -= Time.deltaTime;
            }
        }


        // When player is walking
        if (rb.velocity.x > 0.5f && canJump && (walkFrame < 12 || walkFrame > 16) || rb.velocity.x < -0.5f && canJump && (walkFrame < 12 || walkFrame > 16))
        {
            if (walkCountDown > 0 && canJump)
            {
                walkCountDown -= Time.deltaTime;
            }
            else if (walkCountDown < 0 && walkFrame < 11 && canJump)
            {
                walkCountDown = walkCountDownReset;
                walkFrame++;
            }
            else
            {
                walkFrame = 0;
                walkCountDown = walkCountDownReset;
            }
        }
        // When player is idle 
        else if (canJump && walkFrame < 12 && rb.velocity.x == 0f || canJump && walkFrame > 16 && rb.velocity.x == 0f)
        {
            if (walkCountDown > 0 && walkFrame > 16 && canJump)
            {
                walkCountDown -= Time.deltaTime;
            }
            else if (walkCountDown < 0 && walkFrame < 24 && walkFrame > 16 && canJump)
            {
                walkCountDown = walkCountDownReset;
                walkFrame++;
            }
            else if ((walkFrame > 23 || walkFrame < 12) && canJump)
            {
                Debug.Log("idle reset");
                walkFrame = 17;
                walkCountDown = walkCountDownReset;
            }
        }
        
        
        

        player.sprite = walkFrameSprite[walkFrame];

        
    }
    void walkingSound()
    {
        if (walkingSoundClip != null && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(walkingSoundClip);
        }
    }
    void jumpingSound()
    {
        if(JumpSoundClip != null && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(JumpSoundClip);
        }
        
    }
}
