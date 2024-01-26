using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class exploSionscript : MonoBehaviour
{
    Animator soptunnaAnimation;
   
    // Start is called before the first frame update
    void Start()
    {
        soptunnaAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Projectile>()!=null)
        {
            soptunnaAnimation.Play("Exploading trashcan Animation");
        }
    }
}
