using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int doorNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Called when the player is touching a door
    private void OnTriggerStay2D(Collider2D collision)
    {
        DoorUse doorUse = collision.GetComponent<DoorUse>();
        doorUse.InDoor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
