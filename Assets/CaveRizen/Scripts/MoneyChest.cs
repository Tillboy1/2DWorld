using UnityEngine;

public class MoneyChest : InteractableBase
{
    public bool BeenOpended = false;

    [Header("Drops")]
    public ItemObject[] Items;
    public int amountToDropLow;
    public int amountToDropHigh;

    public override void Interact()
    {
        if (!BeenOpended)
        {
            if (amountToDropLow > amountToDropHigh)
                amountToDropHigh = amountToDropLow;

            int amountDroped = Random.Range(amountToDropLow, amountToDropHigh);

            for (int i = 0; i < amountDroped; i++)
            {
                // Randomises the amount of items dropped and where to
                var ItemToDrop = Random.Range(0, Items.Length);
                float DropAreaHight = Random.Range(100, 300);
                float DropAreaLength = Random.Range(-250, 250);

                // creates the items to drop
                var GO = Instantiate(Items[ItemToDrop].ObjectModel, this.transform.position, new Quaternion(0, 0, 0, 1), this.transform.parent.transform);
                GO.GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(DropAreaLength, DropAreaHight), this.transform.position);
            }

            BeenOpended = true;
        }
    }

    public override void LeavingArea(GameObject PlayerLeaving)
    {
        
    }
}
