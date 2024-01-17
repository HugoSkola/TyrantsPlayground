using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    float eHealth = 1f;

    [SerializeField]
    float DamageTaken = 1f;
    [SerializeField] public GameObject objects;


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
        if(eHealth==1)
        {
            Instantiate(objects, new Vector3(0.5f, 6.9f, 1), Quaternion.identity);
            
        }
    }
    
}
