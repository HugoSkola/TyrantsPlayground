using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public LayerMask player;
    public bool doorsActive;
    public GameObject rebelManager;
    public int maxDoorFrame = 2;
    public float countDown;
    public float countDownReset = 0.09f;
    public bool byDoor;
    int doorInstance;
    public Sprite[] doorInstanceSprite;
    public SpriteRenderer doorType;
    public GameObject door;

    [Header("Audio")]
    public AudioClip DoorOpenSound;
    private AudioSource doorOpenAudioSource;
    //[SerializeField] private float openDelay = 0;
    /*/
    [Space(10)]
    [SerializeField] private AudioSource doorCloseAudioSource = null;
    [SerializeField] private float closeDelay = 0.8f;
    /*/

    // Start is called before the first frame update
    void Start()
    {
        countDown = countDownReset;
        doorOpenAudioSource = GetComponent<AudioSource>();
        doorsActive = true;
    }

    // Called when the player is touching a door
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (doorsActive && (player.value & (1 << collision.gameObject.layer)) != 0)
        {
            byDoor = collision;
            DoorUse doorUse = collision.GetComponent<DoorUse>();
            doorUse.InDoor(door, byDoor);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (doorsActive && (player.value & (1 << collision.gameObject.layer)) != 0)
        {
            byDoor = false;
            DoorUse doorUse = collision.GetComponent<DoorUse>();
            doorUse.InDoor(door, byDoor);
        }
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
        
        if (rebelManager.transform.childCount > 0)
        {
            doorsActive = false;
            byDoor = false;
        }
        else
        {
            doorsActive = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(DoorOpenSound != null)
        {
            doorOpenAudioSource.PlayOneShot(DoorOpenSound);
        }
        
        /*/
        doorCloseAudioSource.PlayDelayed(closeDelay);
        /*/
    }
    
}
