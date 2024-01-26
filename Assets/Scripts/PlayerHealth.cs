using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image heatlbar;
    
    [SerializeField]
    public float maxHealth=100f;

    public float health=100f;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void Hurt(int amount)
    {

        health -= amount;
        if (health <= 0)
        {
            GameOver();
        }
        heatlbar.fillAmount = health / 100f;
    }

    void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
                