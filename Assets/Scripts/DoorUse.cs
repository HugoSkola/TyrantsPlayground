using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUse : MonoBehaviour
{
    GameObject publicDoor;
    bool doorActive;
    public GameObject correspondingDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InDoor(GameObject door, bool byDoor)
    {
        // Makes varibles usable in other functions
        doorActive = byDoor;
        publicDoor = door;
    }

    // Update is called once per frame
    void Update()
    {
        // If the player presses "E" while standing in the door,  
        // it teleports them to the "Exit" connected
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.transform.position = publicDoor.transform.position;
        }


    }
}
