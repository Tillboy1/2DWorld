using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemies : Enemies
{
    public int[] Healthbars;

    [Header("Room")]
    public GameObject BossRoom;

    public void FixedUpdate()
    {
        Move();
    }

    public virtual void Move()
    {
        ClosesestPlayer();
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
                    this.GetComponent<SpriteRenderer>().color = new Color(.5f, 0, .5f);
                    Healthbars[i] = 0;
                    break;
                }
                else
                {
                    BossRoom.GetComponent<BossRoom>().RoomCompleate();
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
