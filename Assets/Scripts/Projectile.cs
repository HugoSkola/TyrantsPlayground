using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float BulletSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
        Rigidbody2D pRigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        BulletMovement();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        GameObject enemyGameobject = collision.gameObject;
        EnemyHealth enemyComponent = enemyGameobject.GetComponent<EnemyHealth>();
        BarrelExplosion barrelComponent = enemyGameobject.GetComponent<BarrelExplosion>();
        

        if(enemyComponent != null)
        {
            enemyComponent.eTakeDamage();
            
        }
        else if (barrelComponent != null)
        {
            barrelComponent.eTakeDamage();
        }
        Destroy(gameObject);
       
    }


    void BulletMovement()
    {
        transform.Translate(Vector2.right * BulletSpeed * Time.deltaTime);

        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

    
}
