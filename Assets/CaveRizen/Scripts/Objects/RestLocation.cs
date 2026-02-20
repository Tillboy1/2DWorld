using UnityEngine;

public class RestLocation : InteractableBase
{
    public GameObject World;

    public override void Interact()
    {
        Player.GetComponent<PlayerStats>().lastRestLocation = this.transform.position;

        Rest();
    }
    public void Rest()
    {
        Debug.Log("Rest");
        foreach (Transform Object in World.transform)
        {
            foreach (Transform RoomsObjs in Object)
            {
                if (RoomsObjs.CompareTag("Enemy"))
                {
                    if (RoomsObjs.GetComponent<AreaEnemies>())
                    {
                        RoomsObjs.GetComponent<AreaEnemies>().Respawn();
                    }
                    
                }
            }
        }
    }
}
