using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerSpawn;
    public GameObject player;
    GameObject spawnedPlayer;
    public GameObject playerFollower;

    // Start is called before the first frame update
    void Start()
    {

        spawnedPlayer = Instantiate(player, playerSpawn.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        PlayerFollow playerFollow = playerFollower.GetComponent<PlayerFollow>();
        playerFollow.PlayerPosition(spawnedPlayer.transform.position);
    }
}
