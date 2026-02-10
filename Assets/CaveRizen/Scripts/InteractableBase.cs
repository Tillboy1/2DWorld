using UnityEngine;

public abstract class InteractableBase : MonoBehaviour
{
    public GameObject Player;
    public bool playerInRange;

    public void Update()
    {
        if (playerInRange && Player.GetComponent<PlayerStats>().interacting)
        {
            Debug.Log("interacting");
            Interact();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            playerInRange = true;
            Player = collision.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            playerInRange = false;
            Player = null;
        }
    }

    public abstract void Interact();
}
