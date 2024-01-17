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
    [SerializeField] public GameObject objects; 

    [SerializeField]
    int spaningbomb = 0;
    public GameObject spawing;

    [SerializeField] public Vector2 spawnPoint;


    // Start is called before the first frame update
    public void Start()
    {
        SpawnController spawingconect = spawing.GetComponent<SpawnController>();
        if (spaningbomb == 3)
        {

            Console.WriteLine("spaningbomb");
            spawingconect.SpawnObject();
            spaningbomb = 0;
        }

    }

    // Update is called once per frame
   public void Update()
    {

        SpawnController spawingconect = spawing.GetComponent<SpawnController>();
        if (spaningbomb == 3)
        {

            Console.WriteLine("spaningbomb");
            spawingconect.SpawnObject();
            spaningbomb = 0;
        }


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
