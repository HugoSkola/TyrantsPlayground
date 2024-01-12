using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int maxDoorFrame = 2;
    public float countDown;
    public float countDownReset = 0.09f;
    public bool byDoor;
    int doorInstance;
    public Sprite[] doorInstanceSprite;
    public SpriteRenderer doorType;
    public GameObject door;

    [Header("Audio")]
    [SerializeField] private AudioSource doorOpenAudioSource = null;
    [SerializeField] private float openDelay = 0;
    [Space(10)]
    [SerializeField] private AudioSource doorCloseAudioSource = null;
    [SerializeField] private float closeDelay = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        countDown = countDownReset;
        
    }

    // Called when the player is touching a door
    private void OnTriggerStay2D(Collider2D collision)
    {
        byDoor = collision;
        DoorUse doorUse = collision.GetComponent<DoorUse>();
        doorUse.InDoor(door, byDoor);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        byDoor = false;
        DoorUse doorUse = collision.GetComponent<DoorUse>();
        doorUse.InDoor(door, byDoor);
    }


    // Update is called once per frame
    void Update()
    {
        // Switches door instance when by the door
        if (byDoor && doorInstance < maxDoorFrame)
        {
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
            }
            else
            {
                countDown = countDownReset;
                doorInstance++;
                Debug.Log("Door+");
            }

            
        }
        // Switches door instance when not by the door
        else if (!byDoor && doorInstance > 0)
        {
            Debug.Log("Door left");
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
            }
            else
            {
                countDown = countDownReset;
                doorInstance--;
                Debug.Log("Door-");
            }
        }

        doorType.sprite = doorInstanceSprite[doorInstance];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        doorOpenAudioSource.PlayDelayed(openDelay);

        doorCloseAudioSource.PlayDelayed(closeDelay);

    }
    
}
