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
    public Vector2 SizeCapasity;

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Camera>() != null && other.CompareTag("Camera"))
        {
            var flowcamholder = other.transform.GetComponentInParent<FlowCamera>();

            //Decides if the screen needs to be shown
            if(flowcamholder.currentAreaName != AreaName)
            {
                flowcamholder.EnteringNewArea(AreaName);
            }
            else
            {
                flowcamholder.currentAreaName = AreaName;
            }

            flowcamholder.locationsSpace = SizeCapasity;

            flowcamholder.limmitNorth = north;
            flowcamholder.limmitEast = east;
            flowcamholder.limmitSouth = south;
            flowcamholder.limmitWest = west;
        }
    }
}
