using UnityEngine;

public class GroundItem : MonoBehaviour
{
    public ItemObject Item;
    public int amount = 1;

    public string GetItemName()
    {
        return Item.name;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.GetComponent<PlayerStats>())
        {
            collision.transform.GetComponent<PlayerStats>().PickUpItem(this.gameObject);
        }
    }
}
