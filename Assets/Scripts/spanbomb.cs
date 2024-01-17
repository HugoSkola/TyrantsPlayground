using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class spanbomb : MonoBehaviour
{
    [SerializeField]
    float eHealth = 1f;

    [SerializeField]
    float DamageTaken = 1f;
    [SerializeField]
    int spaningbomb = 0;
    public GameObject spawing;
    [SerializeField] public GameObject objects;
    [SerializeField] public Vector2 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
       
        {
            OnDestroy();

        }

    }

    // Update is called once per frame
    void Update()
    {

         SpawnController spawingconect = spawing.GetComponent<SpawnController>();
        if (spaningbomb == 3)
        {

            Console.WriteLine("spaningbomb");
            spawingconect.SpawnObject();
            spaningbomb = 0;
        }
        OnDestroy();
    }
    public void bombteleport()
    {
      
        eHealth -= DamageTaken;

        if (eHealth < 0)
        {
            spaningbomb += 1;
            Instantiate(objects, new Vector3(-1, -14, 1), Quaternion.identity);

        }
    }
    void OnDestroy()
    {
        // This code will be executed when the GameObject is destroyed

        // Example: Check if a certain condition is met before performing an action
        if (ShouldPerformAction())
        {
            PerformAction();
        }
    }

    bool ShouldPerformAction()
    {
        // Your condition logic here
        // For example, you might check a variable, state, or other conditions
        return true; // Replace this with your condition
    }

    void PerformAction()
    {
        spaningbomb += 1;// Your action or code to execute when the condition is met
        Debug.Log("Performing action when GameObject is destroyed.");
    }

}
