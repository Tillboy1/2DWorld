using Unity.VisualScripting;
using UnityEngine;

public class GroundCrawler : AreaEnemies
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerStats>())
        {
            Debug.Log("we ran into the player!");

            int damageOutput = Random.Range(attacksPossible[0].attackDamageMin, attacksPossible[0].attackDamageMax + 1);

            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damageOutput);
        }
    }
}
