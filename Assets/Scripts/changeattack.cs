using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class changeattack : MonoBehaviour
{
    // Reference to the GameObject's collider
    private Collider2D oldCollider;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<enemydash>();
    
        


        int randomInt = UnityEngine.Random.Range(0, 4);
        if(randomInt==1)
        {
           
      

        }


        // Get the current collider attached to the GameObject
        oldCollider = GetComponent<Collider2D>();


        // Remove the old collider
        Destroy(oldCollider);

        // Add a new BoxCollider to the GameObject
        BoxCollider2D newCollider = gameObject.AddComponent<BoxCollider2D>();

        // You can customize the size of the box collider if needed
        newCollider.size = new Vector3(2f, 2f, 2f);
    }
}

