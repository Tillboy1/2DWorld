using NUnit.Framework.Internal;
using UnityEngine;

public abstract class InteractableBase : MonoBehaviour
{
    public GameObject Player;
    private GameObject InteractIcon;
    public bool playerInRange;
    public bool hitToInteract;

    private void Awake()
    {
        if (this.transform.childCount != 0)
        {
            InteractIcon = this.transform.GetChild(0).gameObject;
            InteractIcon.SetActive(false);
        }
    }

    public void Update()
    {
        if (playerInRange && Player.GetComponent<PlayerStats>().interacting && !hitToInteract)
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
            if(InteractIcon != null)
                InteractIcon.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            LeavingArea();
            playerInRange = false;
            Player = null;
            if (InteractIcon != null)
                InteractIcon.SetActive(false);
        }
    }

    public abstract void LeavingArea();

    public abstract void Interact();
}
