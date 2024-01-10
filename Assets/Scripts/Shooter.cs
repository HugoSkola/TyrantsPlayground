using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    GameObject BulletPrefab;

    [SerializeField]
    Transform bulletspawn;

    Transform spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootBullet();
            
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(BulletPrefab, bulletspawn.position, Quaternion.identity);
    }
}
