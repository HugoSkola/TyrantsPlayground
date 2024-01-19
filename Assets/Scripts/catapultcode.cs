using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class catapultcode : MonoBehaviour
{
    [SerializeField]
   public int cutscene = 0;
    public GameObject fullscreenSpriteCanvas;
    public bool isInteractionActive = false;

    public float theDurationPictureShowsFor = 1f;

    private void Start()
    {
        HideSpriteCutscene();
    }
    void Update()
    {
        if (cutscene==3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Laddar scener eller nivår för spelet
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision involves the GameObject you want to react to
        if (collision.gameObject.CompareTag("npc"))
        {
            cutscene += 1;
            Debug.Log("Collision occurred! Triggering an event...");
            // Add your custom code here
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
    }
}







