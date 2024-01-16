using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    float eHealth = 1f;

    [SerializeField]
    float DamageTaken = 1f;
  

    // Start is called before the first frame update
    public void Start()
    {
      

    }

    // Update is called once per frame
   public void Update()
    {
       
        

        
    }
    public void eTakeDamage()
    {
        eHealth -= DamageTaken;
        
        if (eHealth == 0)
        {
          

            Destroy(gameObject);
        }
    }
    
}
