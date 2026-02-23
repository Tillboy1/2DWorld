using UnityEngine;

public class WallClimber : AreaEnemies
{
    public override void Move()
    {
        distToPoint = Vector2.Distance(transform.position, Waypoints[nextWaypoint].transform.position);

        transform.position = Vector2.MoveTowards(transform.position, Waypoints[nextWaypoint].transform.position, speed * Time.deltaTime);

        if (distToPoint < 0.2f)
        {
            TurnAround();
        }
    }

    public void TurnAround()
    {
        Vector3 currRot = transform.eulerAngles;
        currRot.z += Waypoints[nextWaypoint].transform.eulerAngles.z;
        transform.eulerAngles = currRot;

        ChooseNextWaypoint();
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
