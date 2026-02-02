using UnityEngine;

public class GroundCrawler : Enemies
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerMovement>();
    }
}
