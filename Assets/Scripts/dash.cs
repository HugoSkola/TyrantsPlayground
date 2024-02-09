using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour
{
    public float dashDistance = 5f;
    public float dashDuration = 0.5f;
    private bool isDashing = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;

        // Store the initial position
        Vector2 startPosition = transform.position;

        // Calculate the end position based on the dash distance and direction
        Vector2 endPosition = startPosition + new Vector2(transform.localScale.x, 0f) * dashDistance* -1;

        // Perform the dash by interpolating the position over time
        float elapsedTime = 0f;
        while (elapsedTime < dashDuration)
        {
            transform.position = Vector2.Lerp(startPosition, endPosition, elapsedTime / dashDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is exactly the end position
        transform.position = endPosition;

        isDashing = false;
    }
}
