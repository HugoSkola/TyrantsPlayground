using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUse : MonoBehaviour
{
    public GameObject correspondingDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InDoor()
    {
        // If the player presses "E" while standing in the door,  
        // it teleports them to the "Exit" connected
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.transform.position = correspondingDoor.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
