using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool byDoor;
    int doorInstance;
    public Sprite[] doorInstanceSprite;
    public SpriteRenderer doorType;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Called when the player is touching a door
    private void OnTriggerStay2D(Collider2D collision)
    {
        byDoor = collision;
        DoorUse doorUse = collision.GetComponent<DoorUse>();
        doorUse.InDoor(door);
    }

    // Update is called once per frame
    void Update()
    {
        if (byDoor && doorInstance != 2)
        {
            
        }
    }
}
