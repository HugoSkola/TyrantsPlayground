using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class runningnpc : MonoBehaviour
{
    public float speed = 5f;          // Speed of the movement
    public float distance = 5f;       // Distance the GameObject will move from its starting position

    private Vector3 startPosition;
    private float direction = 1f;      // Initial movement direction

    void Start()
    {
    
        Rigidbody2D rbObject = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        if (rbObject.isKinematic == true)
        {
            speed = 0;

        }
    }

    void Update()
    {
        GetComponent<grabobject>();
        // Move the GameObject side to side
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
        Rigidbody2D rbObject = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        if (rbObject.isKinematic == true)
        {
            speed = 0;

        }
        //Check if the GameObject reached the maximum distance
        if (Mathf.Abs(transform.position.x - startPosition.x) >= distance)
        {
            // Change the direction to move in the opposite way
            direction *= -1;

            // Optionally, you can randomize the waiting time before changing direction
            // StartCoroutine(RandomizeDirectionChange());
        }
    }

    // Optional: Coroutine to randomize the waiting time before changing direction
    // IEnumerator RandomizeDirectionChange()
     //{
      //   yield return new WaitForSeconds(Random.Range(1f, 3f));
        // direction *= -1;
    //}
   
}
