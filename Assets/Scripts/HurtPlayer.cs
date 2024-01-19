using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    [SerializeField]
    int hurtAmount = 1;
    public GameObject attackAnim;
    SpriteRenderer sr;
    public float countdown;
    public float countdownReset;

    void Start()
    {
        countdown = 0.1f;
        attackAnim.SetActive(false);
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerHealth phealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (phealth != null && countdown < 0f)
        {
            attackAnim.SetActive(true);
            sr.enabled = false;
            phealth.Hurt(hurtAmount);
            Invoke("ResetAnimation", 0.5f);
            countdown = countdownReset;
            return;
        }
        else if (phealth == null)
        {
            return;
        }
        else
        {
            countdown -= Time.deltaTime;
        }

    }

    private void ResetAnimation()
    {
        attackAnim.SetActive(false);
        sr.enabled = true;
    }
}
