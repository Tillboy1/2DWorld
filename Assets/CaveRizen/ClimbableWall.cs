using System.Collections;
using UnityEngine;

public class ClimbableWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            StartCoroutine(WaitToEnter(collision.gameObject));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMovement>() != null)
        {
            collision.GetComponent<PlayerMovement>().isClimbing = false;
        }
        StopCoroutine(WaitToEnter(collision.gameObject));
    }

    IEnumerator WaitToEnter(GameObject collision)
    {
        yield return new WaitForSeconds(0.3f);

        if (collision.GetComponent<PlayerMovement>().UnlockedClimbing)
        {
            collision.GetComponent<PlayerMovement>().isClimbing = true;
        }
    }
}
