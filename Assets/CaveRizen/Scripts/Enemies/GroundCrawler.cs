using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;

public class GroundCrawler : AreaEnemies
{
    [Header("CrawlerStats")]
    public GameObject[] Waypoints;

    int nextWaypoint = 0;
    float distToPoint;

    public float speed;

    private void Update()
    {
        move();
    }

    void move()
    {
        distToPoint = Vector2.Distance(transform.position, Waypoints[nextWaypoint].transform.position);

        transform.position = Vector2.MoveTowards(transform.position, Waypoints[nextWaypoint].transform.position, speed * Time.deltaTime);

        if(distToPoint < 0.2f)
        {
            TurnAround();
        }
    }

    void TurnAround()
    {
        //Add stuff here to turn the sprite

        // Switches between waypoints
        nextWaypoint++;
        if(nextWaypoint >= Waypoints.Length) 
        { 
            nextWaypoint = 0; 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerStats>())
        {
            float HitDirection = 20f;

            int damageOutput = Random.Range(attacksPossible[0].attackDamageMin, attacksPossible[0].attackDamageMax + 1);

            // Knockbacks the player away from the enemy
            if (this.transform.position.x > collision.transform.position.x)
            {
                HitDirection = -20f;
            }
            else
            {
                HitDirection = 20f;
            }
            collision.transform.GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(HitDirection, 28f), this.transform.position, ForceMode2D.Impulse);

            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damageOutput);
        }
    }
}
