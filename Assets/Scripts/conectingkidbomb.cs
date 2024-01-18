using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyCounter : MonoBehaviour
{
    public GameObject kidsconect;
    // Start is called before the first frame update
    public int targetDestroyCount = 3;  // Set the desired number of destroyed game objects
    private int currentDestroyCount = 0;

    void Start()
    {
        // Subscribe to the OnDestroy event of the game objects you want to track
        ObjectDestroyed.OnObjectDestroyed += HandleObjectDestroyed;
    }

    void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks when the script is destroyed
        ObjectDestroyed.OnObjectDestroyed -= HandleObjectDestroyed;
    }

    public void HandleObjectDestroyed()
    {

        // Increment the counter when an object is destroyed
        currentDestroyCount++;

        // Check if the target number of destroyed objects has been reached
        if (currentDestroyCount >= targetDestroyCount)
        {
            SpawnObject();
            Debug.Log("Three game objects have been destroyed! Activating behavior...");
        }
    }

    [SerializeField] public GameObject objects;
    [SerializeField] public Vector2 spawnPoint;


    public void SpawnObject()
    {

        // Check if the objectToSpawn is assigned
        if (objects != null && spawnPoint != null)
        {
            // Instantiate the object at the spawn point position
            Instantiate(objects, new Vector3(0.5f, 6.9f, 1), Quaternion.identity);
        }
        else
        {
            Debug.LogError("Please assign the objectToSpawn and spawnPoint in the inspector.");
        }
    }
}
