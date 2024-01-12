using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    Vector2 playerPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void PlayerPosition(Vector2 player)
    {
        playerPosition = player;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerPosition;
    }
}
