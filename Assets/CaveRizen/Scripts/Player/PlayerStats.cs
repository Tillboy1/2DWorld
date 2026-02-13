using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStats : MonoBehaviour
{
    public Vector2 lastRestLocation;

    public float CurrentHealth;
    public float TotalHealth;

    public bool interacting;
    private bool Abletointeract = true;

    [Header("Combat")]
    public GameObject attackArea;
    public float attackOfSet;

    public bool currentlyDead = false;

    private Vector2 m_moveAmt;
    private Rigidbody2D m_rigidbodyb;

    private void Awake()
    {
        m_rigidbodyb = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        CurrentHealth = TotalHealth;
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if(Abletointeract == true)
        {
            interacting = context.ReadValueAsButton();
        }
    }
    public void Direction(InputAction.CallbackContext context)
    {
        if (!currentlyDead)
        {
            m_moveAmt = context.ReadValue<Vector2>();
            Direction();
        }
    }

    public void Direction()
    {
        if (m_moveAmt.x != 0 && m_moveAmt.y != 0) // Diagonals
        {
            attackArea.transform.localPosition = new Vector3(attackOfSet * m_moveAmt.x, attackOfSet * m_moveAmt.y);

            if(m_moveAmt.x > 0) // 
            {
                Debug.Log("GOING LEFT");
                this.transform.rotation = new Quaternion(this.transform.rotation.x, 0, this.transform.rotation.z, 0);
            }
            if(m_moveAmt.x < 0)
            {
                Debug.Log("GOING Right");
                this.transform.rotation = new Quaternion(this.transform.rotation.x, 180, this.transform.rotation.z, 0);
            }
        }
        else if (m_moveAmt.x == 0 && m_moveAmt.y != 0) /// Looking Up
        {
            //attackArea.transform.localPosition = new Vector3(0, attackOfSet);

            attackArea.transform.localPosition = new Vector3(0, attackOfSet * m_moveAmt.y);
        }
        else // Looking strait Forward
        {
            attackArea.transform.localPosition = new Vector3(attackOfSet, 0);
        }

        if (m_moveAmt.x > 0 && m_moveAmt.y == 0) // Looking Right
        {
            Debug.Log("Going Right");
            this.transform.rotation = new Quaternion(this.transform.rotation.x, 0, this.transform.rotation.z, 0);
        }
        else if (m_moveAmt.x < 0 && m_moveAmt.y == 0) // Looking Left
        {
            Debug.Log("Going Left");
            this.transform.rotation = new Quaternion(this.transform.rotation.x, 180, this.transform.rotation.z, 0);
        }
    }
    public void Interacted()
    {
        interacting = false;
        Abletointeract = false;
        StartCoroutine(WaitReact());
    }

    public void TakeDamage(float damage)
    {
        if (CurrentHealth - damage > 0)
        {
            CurrentHealth -= damage;
        }
        else
        {
            Die();
        }
    }
    private void Die()
    {
        currentlyDead = true;
        this.GetComponent<SpriteRenderer>().color = Color.black;
        Debug.Log("Death Animation");

        StartCoroutine(DeathCo());
    }

    IEnumerator WaitReact()
    {
        yield return new WaitForSeconds(.3f);

        Abletointeract = true;
    }
    IEnumerator DeathCo()
    {
        yield return new WaitForSeconds(2);

        currentlyDead = false;

        CurrentHealth = TotalHealth;
        this.transform.position = lastRestLocation;

        this.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
