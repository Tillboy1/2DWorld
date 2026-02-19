using System;
using UnityEngine;

public enum AttackDirection
{
    Horizontal,
    Vierical,
    Diagonals,
    DiagonalUpwardsOnly,
    DiagonalDownwardsOnly,
    SurroundingArea
}
public enum AttackType
{
    Melee,                  // attack at a close range
    RangedThrown,           // range with a arc
    RangedShot,             // range with a direct shot
    SarroundingArea,        // damages nearby players
    Emmiting,               // used for calling in stuff like spikes in the ground
    summoning,              // calling in other enemies mainly used by bosses
}

public class Enemies : MonoBehaviour
{
    [Header("basic Info")]
    public string EnemyName;
    [TextArea(15, 20)]
    public string description;


    public int id;
    public Sprite EnemySprite;

    //[Header("Animaton in sprite")]
    //public anim holds the animator

    [Header("health")]
    public int healthCurrent;
    public int healthMax;
    public bool Sheild;

    [Header("Combat Stats")]
    public int amountOfAttacks;

    public float attackSpeed;

    public AttacksSlots[] attacksPossible;

    public virtual void TakeDamage(int Damage)
    {
        if (healthCurrent - Damage <= 0)
        {
            healthCurrent -= Damage;
            Die();
        }
        else
        {
            healthCurrent -= Damage;
        }
    }

    public virtual void Die()
    {
        Debug.Log(this.gameObject.name + " died");
        Destroy(this.gameObject);
    }


}
public class Attacklist
{
    public string Name;
    public string Description;
    public int Id;
    public Sprite ImageSprite;

    public int healthCurrent;
    public int healthMax;
    public bool Sheild;

    public int amountOfAttacks;

    public float attackSpeed;
    public float attackRange;

    public AttacksSlots[] AttacksPossible;

    public Attacklist(Enemies enemy)
    {
        Name = enemy.EnemyName;
        Description = enemy.description;
        Id = enemy.id;
        ImageSprite = enemy.EnemySprite;

        healthCurrent = enemy.healthCurrent;
        healthMax = enemy.healthMax;
        Sheild = enemy.Sheild;

        amountOfAttacks = enemy.amountOfAttacks;
        attackSpeed = enemy.attackSpeed;
        AttacksPossible = enemy.attacksPossible;

        AttacksPossible = new AttacksSlots[AttacksPossible.Length];
    }
}

[Serializable]
public class AttacksSlots
{
    public AttackDirection direction;
    public AttackType attackType;
    public GameObject prefab;

    public float AttackRange;

    public int attackDamageMin;
    public int attackDamageMax;
}
