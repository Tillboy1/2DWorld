using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FlowCamera : MonoBehaviour
{
    public string currentAreaName;
    public Camera cam => this.GetComponentInChildren<Camera>();

    public GameObject player;
    public Vector2 Roomspace;
    public Vector2 locationsSpace;
    public Vector3 roomOfset;

    public float CameraMoveSpeed;

    public Vector3 target;

    public bool limmitNorth;
    public bool limmitEast;
    public bool limmitSouth;
    public bool limmitWest;

    private void Update()
    {
        if (player != null)
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
                else if (playpos.y < -locationsSpace.y + roomOfset.y)
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
        else
        {
            var midPointLocation = target;

            float inputX = midPointLocation.x;
            float inputY = midPointLocation.y;

            if (midPointLocation.x > locationsSpace.x + roomOfset.x)
            {
                inputX = locationsSpace.x + roomOfset.x;
            }
            else if (midPointLocation.x < -locationsSpace.x + roomOfset.x)
            {
                inputX = -locationsSpace.x + roomOfset.x;
            }
            else
            {
                inputX = midPointLocation.x;
            }

            if (midPointLocation.y > locationsSpace.y + roomOfset.y)
            {
                inputY = locationsSpace.y + roomOfset.y;
            }
            else if (midPointLocation.y < -locationsSpace.y + roomOfset.y)
            {
                inputY = -locationsSpace.y + roomOfset.y;
            }
            else
            {
                inputY = midPointLocation.y;
            }

            //this.transform.position = player.transform.position;
            //this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position, CameraMoveSpeed * Time.deltaTime);
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(inputX, inputY, midPointLocation.z), CameraMoveSpeed * Time.deltaTime);
        }
    }

    public void NewPlayer()
    {
        Debug.Log("New Player");
        player = FindFirstObjectByType<PlayerMovement>().gameObject;
        this.transform.position = player.transform.position;
    }

    public void ChangeState(bool NewState, Rect Size)
    {
        if (NewState)
        {
            cam.enabled = true;
            cam.rect = Size;
        }
        else
        {
            cam.enabled = false;
            cam.rect = new Rect(0, 1, 1, 1);
        }
    }

    public void EnteringNewArea(string area)
    {
        currentAreaName = area;

        PlayerManager.instance.EnteringNewArea(currentAreaName);
    } 
}
