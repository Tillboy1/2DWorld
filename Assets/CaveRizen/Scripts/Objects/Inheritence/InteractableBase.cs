using UnityEngine;

public abstract class InteractableBase : MonoBehaviour
{
    public GameObject Player;
    private GameObject InteractIcon;
    public bool playerInRange;
    public bool hitToInteract;

    public void Awake()
    {
        InteractIcon = this.transform.GetChild(0).gameObject;
        InteractIcon.SetActive(false);
    }

    public void Update()
    {
        if (playerInRange && Player.GetComponent<PlayerStats>().interacting)
        {
            Debug.Log("interacting");
            Interact();
            Player.GetComponent<PlayerStats>().Interacted();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            playerInRange = true;
            Player = collision.gameObject;
            InteractIcon.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            playerInRange = false;
            Player = null;
            InteractIcon.SetActive(false);
        }
    }

    public abstract void Interact();
}
