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
    [SerializeField]
    int spaningbomb = 0;
    public GameObject spawing;

    // Start is called before the first frame update
    public void Start()
    {
      

    }

    // Update is called once per frame
   public void Update()
    {
        SpawnController spawingconect = spawing.GetComponent<SpawnController>();
        

        if (spaningbomb == 3)
        {

            Console.WriteLine("spaningbomb");
            spawingconect.SpawnObject();
        }
    }
    public void eTakeDamage()
    {
        eHealth -= DamageTaken;
        
        if (eHealth == 0)
        {
            spaningbomb += 1;

            Destroy(gameObject);
        }
    }
    
}
