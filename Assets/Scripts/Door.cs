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

    private void OnTriggerStay2D(Collider2D collision)
    {
        DoorUse doorUse = collision.GetComponent<DoorUse>();
        doorUse.InDoor(true, doorNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
