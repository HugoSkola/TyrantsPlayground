using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class RebelManager : MonoBehaviour
{
    public bool rebelsExist;
    public GameObject rebel;
    GameObject spawnedRebel;
    GameObject rebelAI;
    public GameObject player;
    Vector3 spawnLocation;
    public int LeftOrRight;
    public float spawnCooldown;
    public float spawnCooldownReset;
    public float spawnInterval;
    public float spawnIntervalReset;
    public int spawnWaveAmount;
    public int spawnWaveAmountReset;
    // Start is called before the first frame update
    void Start()
    {
        spawnCooldown = spawnCooldownReset;
        spawnInterval = spawnIntervalReset;
        spawnWaveAmount = spawnWaveAmountReset;
    }

    // Update is called once per frame
    void Update()
    {
        // Randomly decides whether to spawn enemies to the left or right of the player
        LeftOrRight = Random.Range(1, 3);

        if (LeftOrRight == 1)
        {
            spawnLocation = new Vector3(player.transform.position.x - 15, player.transform.position.y + 5, 0);
        }
        else
        {
            spawnLocation = new Vector3(player.transform.position.x + 15, player.transform.position.y + 5, 0);
        }
        
        // Spawns 5 rebels every 30 seconds, can be changed to liking in Unity
        if (!rebelsExist)
        {
            if (spawnCooldown > 0)
            {
                spawnCooldown -= Time.deltaTime;
            }
            else if (spawnCooldown < 0)
            {
                if (spawnInterval > 0)
                {
                    spawnInterval -= Time.deltaTime;
                }
                else if (spawnInterval < 0 && spawnWaveAmount > 0)
                {
                    spawnInterval = spawnIntervalReset;
                    spawnedRebel = Instantiate(rebel, spawnLocation, Quaternion.identity);
                    spawnWaveAmount--;
                }
                else
                {
                    spawnWaveAmount = spawnWaveAmountReset;
                    spawnCooldown = spawnCooldownReset;
                    rebelsExist = true;
                }
            }
        }
        // Sets rebelsExist to false when no children exist
        if (spawnedRebel == null)
        {
            rebelsExist = false;
        }
        // Allows for modifying behaviour for enemy AI by giving it information
        if (spawnedRebel != null)
        {
            RebelAI rebelAI = spawnedRebel.GetComponent<RebelAI>();
            if (rebelsExist)
            {
                rebelAI.RebelAIController(player);
            }
        }
        
        
        
        
    }
}
