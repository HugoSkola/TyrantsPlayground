using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    GameObject BulletPrefab;

    [SerializeField]
    Transform bulletspawn;

    [SerializeField]
    float shootingDelay = 1f;

    float nextFireTime = 0f;

    Transform spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextFireTime)
        {
            ShootBullet();
            nextFireTime = Time.time + 1f / shootingDelay;
        }
        
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(BulletPrefab, bulletspawn.position, Quaternion.identity);

        bool isFacingRight = transform.localScale.x > 0;

        if (!isFacingRight)
        {
            bullet.transform.Rotate(0f, 180f, 0f);
        }
    }
}
