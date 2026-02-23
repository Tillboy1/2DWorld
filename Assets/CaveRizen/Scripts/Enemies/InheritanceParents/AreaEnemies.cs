using UnityEngine;

public class AreaEnemies : Enemies
{
    [Header("GoTo")]
    public GameObject[] Waypoints;

    public int nextWaypoint = 0;
    public float distToPoint;
    public float speed;

    [Header("Drops")]
    public ItemObject[] Items;
    public int amountToDropLow;
    public int amountToDropHigh;


    private void Update()
    {
        Move();
    }

    public virtual void Move()
    {

        distToPoint = Vector2.Distance(transform.position, Waypoints[nextWaypoint].transform.position);

        transform.position = Vector2.MoveTowards(transform.position, Waypoints[nextWaypoint].transform.position, speed * Time.deltaTime);

        if (distToPoint < 0.2f)
        {
            ChooseNextWaypoint();
        }
    }


    public virtual void ChooseNextWaypoint()
    {
        // Switches between waypoints
        nextWaypoint++;
        if (nextWaypoint == Waypoints.Length)
        {
            nextWaypoint = 0;
        }
    }
    public virtual void Respawn()
    {
        currentHealth = maxHealth;
        this.gameObject.SetActive(true);
    }
    public virtual void DropItems()
    {
        int amountDroped = Random.Range(amountToDropLow, amountToDropHigh);

        for (int i = 0; i < amountDroped; i++)
        {
            // Randomises the amount of items dropped and where to
            var ItemToDrop = Random.Range(0, Items.Length);
            float DropAreaHight = Random.Range(0, 30);
            float DropAreaLength = Random.Range(-25, 25);

            // creates the items to drop
            var GO = Instantiate(Items[ItemToDrop].ObjectModel, this.transform.parent);
            GO.GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(DropAreaLength, DropAreaHight), this.transform.position);
        }
    }
}
