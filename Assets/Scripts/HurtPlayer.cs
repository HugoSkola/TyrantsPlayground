using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    [SerializeField]
    int hurtAmount = 1;
    public GameObject attackAnim;
    SpriteRenderer sr;

    void Start()
    {
        attackAnim.SetActive(false);
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerHealth phealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (phealth == null)
        {
            attackAnim.SetActive(true);
            sr.enabled = false;
            Invoke("ResetAnimation", 0.5f);
            return;
        }

        phealth.Hurt(hurtAmount);
    }

    private void ResetAnimation()
    {
        attackAnim.SetActive(false);
        sr.enabled = true;
    }
}
