using UnityEngine;

public class Enemies
{
    [Header("health")]
    public int healthCurrent;
    public int healthMax;
    public bool Sheild;

    [Header("Combat Stats")]
    public int amountOfAttacks;

    public int attackDamageMax;
    public int attackDamageMin;

    public float attackSpeed;
    public float attackRange;

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
        Debug.Log("I Died");
    }
    public virtual void AttackOne()
    {
        Debug.Log("Using attack 1");
    }

}
