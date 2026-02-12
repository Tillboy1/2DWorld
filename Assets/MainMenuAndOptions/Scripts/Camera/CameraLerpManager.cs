using System.Collections.Generic;
using UnityEngine;

public class CameraLerpManager : MonoBehaviour
{
    [SerializeField]
    public Camera MainCamera;
    [SerializeField]
    int currentPosition;
    [SerializeField]
    List<GameObject> allPositions = new List<GameObject>();
    [SerializeField]
    float speed = 10f;

    public void Start()
    {
        if(MainCamera != null)
        {
            MainCamera.transform.position = allPositions[currentPosition].transform.position;
            MainCamera.transform.rotation = allPositions[currentPosition].transform.rotation;
        }
    }

    private void Update()
    {
        if(MainCamera != null && allPositions.Count > currentPosition && allPositions[currentPosition] != null)
        {
            MainCamera.transform.rotation = Quaternion.Lerp(MainCamera.transform.rotation, allPositions[currentPosition].transform.rotation, speed * Time.deltaTime);
            MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, allPositions[currentPosition].transform.position, speed * Time.deltaTime);
        }
    }

    public void SetPosition(int position)
    {
        currentPosition = position;
    }
}
