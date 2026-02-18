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
            if (collision.transform.GetComponent<PlayerStats>().inventory) // If items are not full for coins
            {
                collision.transform.GetComponent<PlayerStats>().PickUpItem(this.gameObject);
                Destroy(this.gameObject);
            }
            else if (collision.transform.GetComponent<PlayerStats>().inventory) // if can only grab so many
            {
                collision.transform.GetComponent<PlayerStats>().PickUpItem(this.gameObject);
                amount = -10;
                Debug.Log("Removed some amount of coins not set correctly");
            }
            else
            {
                Debug.Log("Rolling Pass");
                // Can't grab anything
            }
        }
    }
}
