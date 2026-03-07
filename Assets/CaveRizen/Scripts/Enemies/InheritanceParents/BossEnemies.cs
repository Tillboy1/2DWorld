using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemies : Enemies
{
    public List<GameObject> Players;
    public int[] Healthbars;

    [Header("Movement")]
    public GameObject TargetGO;
    public float distToPoint;
    public float speed;

    public void FixedUpdate()
    {
        Move();
    }

    public void ClosesestPlayer()
    {
        float TempPlayerDistances = 0;
        for (int i = 0; i < Players.Count; i++)
        {
            TempPlayerDistances = Vector2.Distance(transform.position, Players[i].transform.position);
            if(TempPlayerDistances < distToPoint)
            {
                distToPoint = TempPlayerDistances;
                TargetGO = Players[i];
            }
            if (TempPlayerDistances == distToPoint)
            {
                Debug.Log("Same");
            }
        }
    }
    public virtual void Move()
    {
        distToPoint = Vector2.Distance(transform.position, TargetGO.transform.position);

        transform.position = Vector2.MoveTowards(transform.position, TargetGO.transform.position, speed * Time.deltaTime);

        if (distToPoint < 0.2f)
        {
            //TurnAround();
            Debug.Log("In Combat Range");
        }
    }
    public override void TakeDamage(int Damage)
    {
        if (currentHealth - Damage <= 0)
        {
            currentHealth -= Damage;

            for (int i = 0; i < Healthbars.Length; i++)
            {
                if (Healthbars[i] >= 1)
                {
                    currentHealth = Healthbars[i];
                    this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 1);
                    Healthbars[i] = 0;
                    break;
                }
                else
                {
                    Die();
                }
            }
        }
        else
        {
            currentHealth -= Damage;
        }
    }
}
