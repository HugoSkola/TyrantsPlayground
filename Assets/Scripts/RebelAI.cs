using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebelAI : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject playerObj;
    public LayerMask ground;
    public float jumpHeight;
    public float moveSpeed;
    public bool canJump = true;
    public float walkCountDown;
    public float walkCountDownReset;
    public int maxWalkFrame;
    public int walkFrame;
    public float aggroRange;
    public Sprite[] walkFrameSprite;
    public SpriteRenderer rebel;

    // Start is called before the first frame update
    void Start()
    {
        walkCountDown = walkCountDownReset;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
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
        Vector3 playerpos = playerObj.transform.position - transform.position;
        float distance = Mathf.Sqrt(playerpos.x * playerpos.x + playerpos.y * playerpos.y);
        if (distance < aggroRange)
        {
            if (playerpos.x < 0)
            {
                transform.localScale = new Vector2(1, 1);
                rb.velocity = new Vector2(-1 * moveSpeed, rb.velocity.y);
            }
            if (playerpos.x > 0)
            {
                transform.localScale = new Vector2(-1, 1);
                rb.velocity = new Vector2(1 * moveSpeed, rb.velocity.y);
            }
        }
        Debug.Log(playerpos);
            
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

        rebel.sprite = walkFrameSprite[walkFrame];
    }
}
