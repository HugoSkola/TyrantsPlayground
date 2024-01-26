using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image heatlbar;
    
    [SerializeField]
    public float maxHealth=5f;

    public float health=5f;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        heatlbar = GameObject.Find("heatlbar").GetComponent<Image>();
    }

    public void Hurt(int amount)
    {

        health -= amount;
        if (health <= 0)
        {
            GameOver();
        }
        heatlbar.fillAmount = health / 5f;
    }

    void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
                