using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class nextdext : MonoBehaviour
{
    public GameObject fullscreenSpriteCanvas;
    public bool isInteractionActive = true;
    public AnimationClip Animation;

    public float theDurationPictureShowsFor = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            ShowSpriteCutscene();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Laddar scener eller nivår för spelet
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            ShowSpriteCutscene();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Laddar scener eller nivår för spelet
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInteractionActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player leaving");
            isInteractionActive = false;
        }
    }
    */
    void ShowSpriteCutscene()
    {
        fullscreenSpriteCanvas.SetActive(true);

        Invoke("HideSpriteCutscene", theDurationPictureShowsFor);
    }
    /*
    void HideSpriteCutscene()
    {
        fullscreenSpriteCanvas.SetActive(false);
    }
    */
    
       
    

    // Update is called once per frame
   
}
