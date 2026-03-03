using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CameraLimiter : MonoBehaviour
{
    [Header("LocationDetails")]
    public string AreaName;

    [Header("Direction Exemption")]
    public bool north;
    public bool east;
    public bool south;
    public bool west;

    [Header("Size Of Space")]
    public Vector2 sizeCapasity;
    public Vector3 areaOfset;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            
            FlowCamera holder = other.GetComponent<PlayerMovement>().CurrentCamera;
            
            if (holder.GetComponentInChildren<Camera>() != null && holder.transform.GetChild(0).CompareTag("MainCamera"))
            {
                var flowcamholder = holder.GetComponent<FlowCamera>();

                EnteringArea(flowcamholder);
            }
        }
    }

    public void EnteringArea(FlowCamera flowcamholder)
    {
        //Decides if the screen needs to be shown
        if (flowcamholder.currentAreaName != AreaName)
        {
            flowcamholder.EnteringNewArea(AreaName);
        }
        else
        {
            flowcamholder.currentAreaName = AreaName;
        }

        flowcamholder.locationsSpace = sizeCapasity;
        flowcamholder.roomOfset = areaOfset;

        flowcamholder.limmitNorth = north;
        flowcamholder.limmitEast = east;
        flowcamholder.limmitSouth = south;
        flowcamholder.limmitWest = west;
    }
}
