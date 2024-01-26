using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
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

