using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cutscenestarter : MonoBehaviour
{
    public GameObject fullscreenSpriteCanvas;
    public bool isInteractionActive = false;
    ObjectDestroyCounter ObjectDestroyCounter;

    public float theDurationPictureShowsFor = 1f;
    // Start is called before the first frame update
    void Start()
    {
        fullscreenSpriteCanvas.SetActive(false);

    }
    
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) && isInteractionActive && ObjectDestroyCounter.currentDestroyCount > 6)
        {
            ShowSpriteCutscene();
        }
    }
    
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
    
    void ShowSpriteCutscene()
    {
        fullscreenSpriteCanvas.SetActive(true);

        Invoke("HideSpriteCutscene", theDurationPictureShowsFor);
    }
    void HideSpriteCutscene()
    {
        fullscreenSpriteCanvas.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Laddar scener eller nivår för spelet
    }
}
