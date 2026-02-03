using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStats : MonoBehaviour
{
    public float CurrentHealth;
    public float TotalHealth;

    [Header("Direction")]
    public InputActionAsset inputActions;

    private InputAction m_moveAction;

    [Header("Combat")]
    public GameObject attackArea;
    public float attackOfSet;

    private Vector2 m_moveAmt;
    private Rigidbody2D m_rigidbodyb;


    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }
    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        m_moveAction = InputSystem.actions.FindAction("Move");
        m_rigidbodyb = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        CurrentHealth = TotalHealth;
    }

    private void Update()
    {
        m_moveAmt = m_moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Direction();
    }

    public void Direction()
    {
        if (m_moveAmt.x > 0 && m_moveAmt.y == 0) // Looking Right
        {
            this.transform.rotation = new Quaternion(this.transform.rotation.x, 0, this.transform.rotation.z, 0);
        }
        else if (m_moveAmt.x < 0&& m_moveAmt.y == 0) // Looking Left
        {
            this.transform.rotation = new Quaternion(this.transform.rotation.x, 180, this.transform.rotation.z, 0);
        }
        else if (m_moveAmt.x != 0 && m_moveAmt.y != 0)
        {
             attackArea.transform.localPosition = new Vector3(attackOfSet * -m_moveAmt.x, attackOfSet * m_moveAmt.y);
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
    }
    public void TakeDamage(float damage)
    {
        if (CurrentHealth - damage > 0)
        {
            CurrentHealth -= damage;
        }
        else
        {
            CurrentHealth = 0;
            this.GetComponent<SpriteRenderer>().color = Color.black;
            Debug.Log("You Died");
        }
    }
}
