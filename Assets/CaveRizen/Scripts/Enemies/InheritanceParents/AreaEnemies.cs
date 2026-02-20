using UnityEngine;

public class AreaEnemies : Enemies
{
    public ItemObject[] Items;
    public int amountToDropLow;
    public int amountToDropHigh;

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
