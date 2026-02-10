using UnityEngine;

public class RestLocation : InteractableBase
{
    public override void Interact()
    {
        Debug.Log("Rest");
        Player.GetComponent<PlayerStats>().lastRestLocation = this.transform.position;
    }
}
