using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebelAI : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject rebelPos;
    public LayerMask ground;
    public float jumpHeight;
    public float moveSpeed;
    public bool canJump = true;
    public float walkCountDown;
    public float walkCountDownReset;
    public int maxWalkFrame;
    int walkFrame;
    public Sprite[] walkFrameSprite;
    public SpriteRenderer rebel;

    // Start is called before the first frame update
    void Start()
    {
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

    public void RebelAIController(GameObject player)
    {
        Vector2 playerpos = player.transform.position - rebelPos.transform.position;
        Debug.Log(playerpos);
        if (playerpos.x < 0)
        {
            transform.localScale = new Vector2(1, 1);
            rb.velocity = new Vector2(-5, rb.velocity.y);
        }
        if (playerpos.x > 0)
        {
            transform.localScale = new Vector2(-1, 1);
            rb.velocity = new Vector2(5, rb.velocity.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }
}
