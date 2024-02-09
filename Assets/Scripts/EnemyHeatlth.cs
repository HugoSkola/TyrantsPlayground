using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public float eHealth = 30f;
    private float maxeHealth;

    [SerializeField]
    float DamageTaken = 1f;
    [SerializeField] public GameObject objects;

    [SerializeField]
    public int spaningbomb = 0;
    public GameObject spawing;

    [SerializeField] public Vector2 spawnPoint;


    public Image Bossbar;



    // Start is called before the first frame update


    void Start()
    {

        Bossbar = GameObject.Find("").GetComponent<Image>();
        SpawnController spawingconect = spawing.GetComponent<SpawnController>();
        if (spaningbomb == 3)
        {

            Console.WriteLine("spaningbomb");
            spawingconect.SpawnObject();
            spaningbomb = 0;
            Console.WriteLine("get");
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
        Bossbar.fillAmount = eHealth / 30f;


    }
   
}


