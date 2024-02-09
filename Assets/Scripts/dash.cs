using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour
{
    public float dashDistance = 5f;
    public float dashDuration = 0.5f;
    private bool isDashing = false;
    public float cooldowndash = 1f;
    public float forceMagnitude = 10f;

    private void Start()
    {
     
        cooldowndash = -1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && cooldowndash< 0)
        {
            dashDuration=0.5f;
            StartCoroutine(Dash());
            cooldowndash = 1;
        }
        else if (cooldowndash > 0)
        {
            cooldowndash -= Time.deltaTime;
        }

    }
  
    
    void OnCollisionEnter2D(Collision2D collision)
    {
  

        if (collision.gameObject.CompareTag("wall"))
        {

            transform.localScale = new Vector2(1, 1);
            

            isDashing = false;
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;

        // Store the initial position
        Vector2 startPosition = transform.position;

        // Calculate the end position based on the dash distance and direction
        Vector2 endPosition = startPosition + new Vector2(transform.localScale.x, 0f) * dashDistance * -1;

        // Perform the dash by interpolating the position over time
        float elapsedTime = 0f;
        while (elapsedTime < dashDuration)
        {
            transform.position = Vector2.Lerp(startPosition, endPosition, elapsedTime / dashDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }


        transform.position = endPosition;
        
        isDashing = false;
    }
}
