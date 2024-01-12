using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class puase : MonoBehaviour
{
    public GameObject pausemenu;

    public static bool ispaused;
    void Start()
    {
        pausemenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            if(ispaused)
            {
                Resumegame();
            }
            else
            {
                Pausegame();
            }

        }

    }
    public void Pausegame() // den här pausar spelet
    { 
        pausemenu.SetActive(true);
        Time.timeScale = 0f; 
        ispaused = true;
        

    }
    public void Resumegame() // den här slutar pausa spelet
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        ispaused = false;



    
    }
}
