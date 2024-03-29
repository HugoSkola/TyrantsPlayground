using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyCounter : MonoBehaviour
{
    public GameObject kidsconect;
    public GameObject cutsceneStarter;
    // Start is called before the first frame update
    public int targetDestroyCount = 7;  // Set the desired number of destroyed game objects
    public int currentDestroyCount = 0;

    void Start()
    {
        currentDestroyCount = 0;
        // Subscribe to the OnDestroy event of the game objects you want to track
        ObjectDestroyed.OnObjectDestroyed += HandleObjectDestroyed;
    }

    void OnDestroy()
    {
        Cutscenestarter cutscene = cutsceneStarter.GetComponent<Cutscenestarter>();
        cutscene.KidIsKilled();
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

    private void Update()
    {
        Cutscenestarter cutscene = cutsceneStarter.GetComponent<Cutscenestarter>();
        cutscene.NumberOfKidsDestroyed(currentDestroyCount);
    }


    public void SpawnObject()
    {

        // Check if the objectToSpawn is assigned
        if (objects != null && spawnPoint != null)
        {
            // Instantiate the object at the spawn point position
            Instantiate(objects, new Vector3(11.97f, 3f, 1), Quaternion.identity);
        }

        else
        {
            Debug.LogError("Please assign the objectToSpawn and spawnPoint in the inspector.");
        }
    }
}
