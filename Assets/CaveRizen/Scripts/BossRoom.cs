using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    public bool HasCompleated;
    public GameObject BossToSpawn;
    public Vector2 LocationToSpawn;
    public bool IsInFight;

    public GameObject[] Door;
    private float StartYLocation;
    public float GoToY;
    public float distToPoint;
    private bool GateMovingClosed;
    private bool GateMovingOpen;
    private float GateSpeed = 3;

    public List<GameObject> Players;

    private void Start()
    {
        StartYLocation = this.transform.position.y;
    }
    public void Update()
    {
        if (GateMovingClosed)
        {
            GateClose();
        }
        else if (GateMovingOpen)
        {
            GateOpen();
        }
    }

    public void RoomCompleate()
    {
        HasCompleated = true;
        IsInFight = false;
        GateMovingOpen = true;
    }
    public void GateClose()
    {
        Debug.Log("Close");

        distToPoint = Vector2.Distance(Door[0].transform.localPosition, new Vector3(Door[0].transform.localPosition.x, GoToY, Door[0].transform.localPosition.y));

        for (int i = 0; i < Door.Length; i++)
        {
            Door[i].transform.localPosition = Vector2.MoveTowards(Door[i].transform.localPosition, new Vector2(Door[i].transform.localPosition.x, GoToY), GateSpeed * Time.deltaTime);
        }

        if (distToPoint < 0.1f)
        {
            GateMovingClosed = false;

            var SpawnedBoss = Instantiate(BossToSpawn, LocationToSpawn, new Quaternion(0, 0, 0, 1) );
            SpawnedBoss.GetComponent<BossEnemies>().BossRoom = this.gameObject;
            for (int i = 0; i < Players.Count; i++)
            {
                SpawnedBoss.GetComponent<BossEnemies>().Players.Add(Players[i]);
            }
        }
    }
    public void GateOpen()
    {
        distToPoint = Vector2.Distance(Door[0].transform.localPosition, new Vector3(Door[0].transform.localPosition.x, StartYLocation, Door[0].transform.localPosition.y));

        for (int i = 0; i < Door.Length; i++)
        {
            Door[i].transform.localPosition = Vector2.MoveTowards(Door[i].transform.localPosition, new Vector2(Door[i].transform.localPosition.x, StartYLocation), GateSpeed * Time.deltaTime);
        }

        if (distToPoint < 0.1f)
        {
            GateMovingOpen = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMovement>() != null && !IsInFight && !HasCompleated)
        {
            Players.Add(collision.gameObject);
            StartCoroutine(DoorClose());
        }
    }

    IEnumerator DoorClose()
    {
        yield return new WaitForSeconds(1f);

        GateMovingClosed = true;
        IsInFight = true;
    }
}
