using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float minCamera;
    public float maxCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        Vector2 clampedCamera = new Vector2(player.transform.position.x , Mathf.Clamp(player.transform.position.y, minCamera, maxCamera));
        transform.position = clampedCamera;
    }
}
