using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarrelExplosion : MonoBehaviour
{
    public bool active;
    public float countdown;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void eTakeDamage()
    {
        active = true;
        Instantiate(explosion, transform.position, Quaternion.identity, gameObject.transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            countdown -= Time.deltaTime;
        }

        if (countdown <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
