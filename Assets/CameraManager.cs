using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    public FlowCamera groupCamera;
    public List<PlayerMovement> allPlayers = new List<PlayerMovement>();

    [SerializeField]
    float splitDistance = 5f;
    bool isCameraSplit;
    bool isLeftScreenDiffRooms;

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

                Debug.Log(groupCamera);
                groupCamera.GetComponent<FlowCamera>().locationsSpace = allPlayers[0].CurrentCamera.GetComponent<FlowCamera>().locationsSpace;
                groupCamera.GetComponent<FlowCamera>().roomOfset = allPlayers[0].CurrentCamera.GetComponent<FlowCamera>().roomOfset;
                groupCamera.target = allpossitions / allPlayers.Count;
            }
        }
        WorkingOutDistance();
    }

    private void WorkingOutDistance()
    {
        for (int x = 0; x < allPlayers.Count; x++)
        {
            for (int y = 0; y < allPlayers.Count; y++)
            {
                if (allPlayers[x].CurrentCamera.GetComponent<FlowCamera>().roomOfset == allPlayers[y].CurrentCamera.GetComponent<FlowCamera>().roomOfset)
                {
                    if (allPlayers[x] != allPlayers[y])
                    {
                        if ((allPlayers[x].transform.position - allPlayers[y].transform.position).magnitude > splitDistance)
                        {
                            if (!isCameraSplit)
                            {
                                SplitCamera(allPlayers[x].transform.position.x < allPlayers[y].transform.position.x);
                            }
                        }
                        else
                        {
                            if (isCameraSplit)
                            {
                                MergeCameras();
                            }
                        }
                    }
                }
                else
                {
                    SplitCamera(isLeftScreenDiffRooms);
                }
            }
        }
    }

    public void SplitCamera(bool PlayerZeroOnLeft)
    {
        isLeftScreenDiffRooms = PlayerZeroOnLeft;
        isCameraSplit = true;
        for (int i = 0; i < allPlayers.Count; i++)
        {
            if(PlayerZeroOnLeft)
            {
                if(i == 0)
                {
                    allPlayers[i].CurrentCamera.ChangeState(true, new Rect(0, 0, 0.5f, 1));
                }
                else
                {
                    allPlayers[i].CurrentCamera.ChangeState(true, new Rect(0.5f, 0, 0.5f, 1));
                }
            }
            else
            {

                if (i == 0)
                {
                    allPlayers[i].CurrentCamera.ChangeState(true, new Rect(0.5f, 0, 0.5f, 1));
                }
                else
                {
                    allPlayers[i].CurrentCamera.ChangeState(true, new Rect(0, 0, 0.5f, 1));
                }
            }
        }
    }

    public void MergeCameras()
    {
        isCameraSplit = false;
        for (int i = 0; i < allPlayers.Count; i++)
        {

            allPlayers[i].CurrentCamera.ChangeState(false, new Rect(0, 0, 1, 1));
        }
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
