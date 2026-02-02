using UnityEngine;

public class FlowCamera : MonoBehaviour
{
    public string currentAreaName;
    public GameObject locationScreen;

    public GameObject player;
    public Vector2 locationsSpace;
    public Vector3 roomOfset;

    public float CameraMoveSpeed;

    public bool limmitNorth;
    public bool limmitEast;
    public bool limmitSouth;
    public bool limmitWest;


    public void Update()
    {
        if (player.transform.position != this.transform.position)
        {
            var playpos = player.transform.position;

            float inputX = playpos.x;
            float inputY = playpos.y;

            if (playpos.x > locationsSpace.x + roomOfset.x)
            {
                inputX = locationsSpace.x + roomOfset.x;
            }
            else if (playpos.x < -locationsSpace.x + roomOfset.x)
            {
                inputX = -locationsSpace.x + roomOfset.x;
            }
            else
            {
                inputX = playpos.x;
            }

            if (playpos.y > locationsSpace.y + roomOfset.y)
            {
                inputY = locationsSpace.y + roomOfset.y;
            }
            else if(playpos.y < -locationsSpace.y + roomOfset.y)
            {
                inputY = -locationsSpace.y + roomOfset.y;
            }
            else
            {
                inputY = playpos.y;
            }

            //this.transform.position = player.transform.position;
            //this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position, CameraMoveSpeed * Time.deltaTime);
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(inputX, inputY, playpos.z), CameraMoveSpeed * Time.deltaTime);
        }
    }

    public void EnteringNewArea(string area)
    {
        currentAreaName = area;

        Debug.Log("entering " + area);

        //locationScreen.SetActive(true);
        // Set the locationScreen
    } 
}
