using UnityEngine;

public class FlowCamera : MonoBehaviour
{
    public string currentAreaName;
    private GameObject locationScreen;

    public GameObject player;
    public Vector2 locationsSpace;

    public bool limmitNorth;
    public bool limmitEast;
    public bool limmitSouth;
    public bool limmitWest;

    public void FixedUpdate()
    {
        if (player.transform.position != this.transform.position)
        {
            // move to the position of the player
        }
    }

    public void EnteringNewArea(string area)
    {
        currentAreaName = area;
    } 
}
