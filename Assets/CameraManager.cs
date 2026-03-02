using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    public FlowCamera groupCamera;
    public List<PlayerMovement> allPlayers = new List<PlayerMovement>();

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    private void Update()
    {
        if(groupCamera != null)
        {
            if (allPlayers.Count > 0)
            {
                Vector3 allpossitions = new Vector3();
                foreach (PlayerMovement player in allPlayers)
                {
                    allpossitions = allpossitions + player.transform.position;
                }

                groupCamera.GetComponent<FlowCamera>().locationsSpace = allPlayers[0].CurrentCamera.GetComponent<FlowCamera>().locationsSpace;
                groupCamera.GetComponent<FlowCamera>().roomOfset = allPlayers[0].CurrentCamera.GetComponent<FlowCamera>().roomOfset;
                groupCamera.target = allpossitions / allPlayers.Count;
            }
        }
    }

    private void WorkingOutDistance()
    {

    }

    public void PlayerJoined(PlayerInput player)
    {
        PlayerMovement LocalPlayer;
        if (player.TryGetComponent<PlayerMovement>(out LocalPlayer))
        {
            allPlayers.Add(LocalPlayer);
        }
    }
    public void PlayerLeft(PlayerInput player)
    {
        PlayerMovement LocalPlayer;
        if(player.TryGetComponent<PlayerMovement>(out LocalPlayer))
        {
            if (allPlayers.Contains(LocalPlayer))
            {
                allPlayers.Remove(LocalPlayer);
            }
        }
    }
}
