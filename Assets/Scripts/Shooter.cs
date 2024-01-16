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

    public GameObject ShooterAnimation;
    SpriteRenderer sr;
    
    public AudioClip ShootingSound;

    private AudioSource audioSource;
    
    Transform spawn;
    // Start is called before the first frame update
    void Start()
    {
        ShooterAnimation.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time >= nextFireTime)
        {
            ShooterAnimation.SetActive(true);
            sr.enabled = false;
            ShootBullet();
            Invoke("ResetAnimation", 0.5f);
        }
    }
    private void ResetAnimation()
    {
        ShooterAnimation.SetActive(false);
        sr.enabled = true;
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
