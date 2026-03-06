using JetBrains.Annotations;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerStats>())
        {
            collision.GetComponent<PlayerStats>().TakeDamage(damage);
            collision.GetComponent<PlayerMovement>().ReturnToStable();
        }
        if (collision.GetComponent<Enemies>())
        {
            collision.GetComponent<Enemies>().TakeDamage(damage * 5);
        }
    }
}
