using JetBrains.Annotations;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(" Entering hit");
        if(collision.GetComponent<PlayerStats>())
        {
            collision.GetComponent<PlayerStats>().TakeDamage(damage);
            collision.GetComponent<PlayerMovement>().rb.AddForceAtPosition(new Vector2(0, 3000), new Vector3(this.transform.position.x, collision.transform.position.y - 2f, collision.transform.position.z));
        }
        if (collision.GetComponent<Enemies>())
        {
            collision.GetComponent<Enemies>().TakeDamage(damage * 5);
        }


    }
}
