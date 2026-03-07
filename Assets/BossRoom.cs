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
    public float GoToY;
    public float distToPoint;
    private bool GateMoving;
    private float GateSpeed;

    public List<GameObject> Players;

    public void Update()
    {
        if (GateMoving)
        {
            Gatemovement();
        }
    }

    public void Gatemovement()
    {
        distToPoint = Vector2.Distance(Door[0].transform.localPosition, new Vector3(Door[0].transform.localPosition.x, GoToY, Door[0].transform.localPosition.y));

        for (int i = 0; i < Door.Length; i++)
        {
            Door[i].transform.localPosition = Vector2.MoveTowards(Door[i].transform.localPosition, new Vector2(Door[i].transform.localPosition.x, GoToY), GateSpeed * Time.deltaTime);
        }

        if (distToPoint < 0.1f)
        {
            GateMoving = false;

            var SpawnedBoss = Instantiate(BossToSpawn, LocationToSpawn, new Quaternion(0, 0, 0, 1) );
            for (int i = 0; i < Players.Count; i++)
            {
                SpawnedBoss.GetComponent<BossEnemies>().Players.Add(Players[i]);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMovement>() != null && !IsInFight)
        {
            Players.Add(collision.gameObject);
            StartCoroutine(DoorClose());
        }
    }

    IEnumerator DoorClose()
    {
        yield return new WaitForSeconds(2);

        GateMoving = true;
        IsInFight = true;
    }
}
