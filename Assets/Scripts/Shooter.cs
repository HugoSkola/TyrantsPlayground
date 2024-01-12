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
    
    
    public AudioClip ShootingSound;

    private AudioSource audioSource;
    
    Transform spawn;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time >= nextFireTime)
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(BulletPrefab, bulletspawn.position, Quaternion.identity);
        
        bool isFacingLeft = transform.localScale.x < 0;

        if (!isFacingLeft)
        {
            bullet.transform.Rotate(0f, 180f, 0f);
        }

        nextFireTime = Time.time + 1f / shootingDelay;

        if (ShootingSound != null)
        {
            audioSource.PlayOneShot(ShootingSound);
        }
    }
}
