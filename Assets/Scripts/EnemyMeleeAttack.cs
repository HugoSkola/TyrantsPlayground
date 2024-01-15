using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    bool attacking;
    public float attackDelay;
    public float attackDelayReset;
    GameObject player;
    public LayerMask playerLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((playerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            player = collision.gameObject;
            attacking = true;

        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (attacking && attackDelay < 0)
        {
            attacking = false;
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            playerHealth.Hurt(1);
            attackDelay = attackDelayReset;
        }
        else if (attacking)
        {
            attackDelay -= Time.deltaTime;
        }
        
    }
}
