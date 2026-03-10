using UnityEngine;

public class RestLocation : InteractableBase
{
    public GameObject Areas;

    public override void LeavingArea()
    {
        Player.GetComponent<PlayerStats>().IsResting = false;
    }

    public override void Interact()
    {
        Player.GetComponent<PlayerStats>().lastRestLocation = this.transform.position;

        Rest();
    }
    public void Rest()
    {
        Debug.Log("Rest");
        Player.GetComponent<PlayerStats>().IsResting = true;
        Player.GetComponent<PlayerStats>().CurrentHealth = Player.GetComponent<PlayerStats>().maxHealth;
        Player.GetComponent<PlayerStats>().statsUI.LoadMasks();

        // Respawning Mechanic
        foreach (Transform Object in Areas.transform)
        {
            foreach (Transform RoomsObjs in Object)
            {
                foreach (Transform Objects in RoomsObjs)
                {
                    if (Objects.CompareTag("Enemy"))
                    {
                        if (Objects.GetComponent<AreaEnemies>())
                        {
                            Objects.GetComponent<AreaEnemies>().Respawn();
                        }
                    }
                }
            }
        }
    }
}
