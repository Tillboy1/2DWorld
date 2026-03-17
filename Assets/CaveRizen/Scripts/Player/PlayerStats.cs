using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStats : MonoBehaviour
{
    private GameObject TestSpawnLocation;
    public Vector2 lastRestLocation;

    [Header("UI")]
    public bool UIOpen;

    [Header("Health")]
    public float CurrentHealth;
    public float maxHealth;
    public float tempHealth = 0;

    public bool interacting;
    private bool ableToInteract = true;

    [Header("Inventory")]
    public InventoryObject inventory;

    public int worldWideCurrency;
    public int worldWideMaxCurrency;

    public int[] LocalCurrency = new int[2];
    public int localCurrencyMax;

    [Header("Combat")]
    public AttackArea attackArea;
    public float attackOfSet;
    public int damage;
    private bool AbleToAttack = true;

    public bool AbleToMove = true;
    public bool currentlyDead = false;
    public bool IsResting;

    [Header("Focus")]
    public float focusAmount;
    public float MaxFocus = 100;
    public int focusOnHit = 10;

    public float FocusTaken = 70;
    public int HealingAmount;
    public bool AbilityReady = false;

    [Header("Shell")]
    public ShellDesigns CurrentShell;
    public ShellDesigns[] ShellsUnlocked;

    private Vector2 m_moveAmt;
    private Rigidbody2D m_rigidbodyb;

    private void Awake()
    {
        m_rigidbodyb = GetComponent<Rigidbody2D>();

        TestSpawnLocation = GameObject.FindGameObjectWithTag("TestUsage");
        if (TestSpawnLocation != null)
        {
            this.transform.position = TestSpawnLocation.transform.position;
        }
        else
        {
            this.transform.position = lastRestLocation;
        }
    }
    public void Start()
    {
        CurrentHealth = maxHealth;
    }

    public void Focus(InputAction.CallbackContext context)
    {
        if(focusAmount >= 75)
        {
            if(CurrentHealth + HealingAmount > maxHealth)
            {
                CurrentHealth = maxHealth;
            }
            else
            {
                CurrentHealth += HealingAmount;
            }
            PlayerManager.instance.LoadMasks();
            PlayerManager.instance.LoadFocus();
        }
    }
    public void Interact(InputAction.CallbackContext context)
    {
        if (ableToInteract == true)
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
    public void OpenMap(InputAction.CallbackContext context)
    {
        if (!UIOpen)
        {
            UIOpen = true;
            PlayerManager.instance.Map();
            AbleToMove = false;
        }
        else
        {
            UIOpen = false;
            PlayerManager.instance.CloseUI();
            AbleToMove = true;
        }
    }
    public void CharacterMenuBTN(InputAction.CallbackContext context)
    {
        if (!UIOpen)
        {
            UIOpen = true;
            PlayerManager.instance.CharacterMenu();
            AbleToMove = false;
        }
        else
        {
            UIOpen = false;
            PlayerManager.instance.CloseUI();
            AbleToMove = true;
        }

    }
    public void OpenMenu(InputAction.CallbackContext context)
    {
        PlayerManager.instance.Menu(this.gameObject);
        AbleToMove = false;
    }

    public void Direction()
    {
        if (m_moveAmt.x != 0 && m_moveAmt.y != 0) // Diagonals
        {
            attackArea.transform.localPosition = new Vector3(attackOfSet * m_moveAmt.x, attackOfSet * m_moveAmt.y);

            if(m_moveAmt.x > 0) // 
            {
                this.transform.rotation = new Quaternion(this.transform.rotation.x, 0, this.transform.rotation.z, 0);
            }
            if(m_moveAmt.x < 0)
            {
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
            this.transform.rotation = new Quaternion(this.transform.rotation.x, 0, this.transform.rotation.z, 0);
        }
        else if (m_moveAmt.x < 0 && m_moveAmt.y == 0) // Looking Left
        {
            this.transform.rotation = new Quaternion(this.transform.rotation.x, 180, this.transform.rotation.z, 0);
        }
    }
    public void Interacted()
    {
        interacting = false;
        ableToInteract = false;
        StartCoroutine(WaitReact());
    }


    public void DealDamage(InputAction.CallbackContext context)
    {
        
        List<GameObject> attackAreaObject = this.GetComponentInChildren<AttackArea>().Attackobject;

        for (int i = 0; i < attackAreaObject.Count; i++)
        {
            if (attackAreaObject[i].transform.GetComponent<Enemies>())
            {
                if (AbleToAttack)
                {
                    attackAreaObject[i].transform.GetComponent<Enemies>().TakeDamage(damage);

                    // Soul Focus
                    if(focusAmount + focusOnHit >= MaxFocus)
                    {
                        focusAmount = MaxFocus;
                    }
                    else
                    {
                        focusAmount += focusOnHit;
                    }

                    if (focusAmount >= FocusTaken)
                    {
                        AbilityReady = true;
                    }
                    PlayerManager.instance.LoadFocus();

                    //Reset Attacks
                    AbleToAttack = false;
                    StartCoroutine(WaitAttack());
                }
            }
            else if (attackAreaObject[i].transform.GetComponent<BreakableWall>())
            {
                if (AbleToAttack)
                {
                    attackAreaObject[i].transform.GetComponent<BreakableWall>().TakeDamage();
                    AbleToAttack = false;
                    StartCoroutine(WaitAttack());
                }
            }
            else if (attackAreaObject[i].transform.GetComponent<InteractableBase>())
            {
                if (AbleToAttack && attackAreaObject[i].transform.GetComponent<InteractableBase>().hitToInteract)
                {
                    attackAreaObject[i].transform.GetComponent<InteractableBase>().Interact();
                    AbleToAttack = false;
                    StartCoroutine(WaitAttack());
                }
            }
            else if (attackAreaObject[i].transform.GetComponent<HitLever>())
            {
                if (AbleToAttack)
                {
                    attackAreaObject[i].transform.GetComponent<HitLever>().Interact();
                    AbleToAttack = false;
                    StartCoroutine(WaitAttack());
                }
            }
        }

        StartCoroutine(AttackAn());
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("Take Damage");
        if (tempHealth > 0)
        {
            if(tempHealth - damage < 0)
            {
                Debug.Log("spillover");
                float tempint = damage - tempHealth;

                tempHealth = 0;
                Debug.Log(damage + " = " + tempint);
                damage = tempint;
            }
            else if(tempHealth - damage == 0)
            {
                tempHealth = 0;
                damage = 0;
            }
            else
            {
                Debug.Log("tempHealth Damage");

                float tempint = tempHealth - damage;

                tempHealth -= tempint;
                damage = 0;
            }
        }

        if (CurrentHealth - damage > 0)
        {
            CurrentHealth -= damage;
            PlayerManager.instance.LoadMasks();
        }
        else
        {
            CurrentHealth = 0;
            PlayerManager.instance.LoadMasks();
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

    public void Bind(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("started");
        }
        if (context.performed)
        {
            Debug.Log("Held");

            if (AbilityReady)
            {
                if (CurrentHealth + HealingAmount >= maxHealth)
                {
                    CurrentHealth = maxHealth;
                }
                else
                {
                    CurrentHealth += maxHealth;
                }

                focusAmount -= FocusTaken;

                PlayerManager.instance.LoadMasks();
                PlayerManager.instance.LoadFocus();
            }
            else
            {
                Debug.Log("Not Enough Focus");
            }
        }
    }


    public void PickUpItem(GameObject objectToPickUp)
    {
        GroundItem GroundObject = objectToPickUp.GetComponent<GroundItem>();

        var item = GroundObject.gameObject.GetComponent<GroundItem>();

        // Keiran testing

        if (item.Item.IsCurrency)
        {
            if (item.Item.Id == 0)
            {
                if (GroundObject.amount + worldWideCurrency <= worldWideMaxCurrency)
                {
                    worldWideCurrency += GroundObject.amount;
                    Destroy(objectToPickUp.gameObject);
                }
                else if (1 + worldWideCurrency < worldWideMaxCurrency)
                {
                    int count = 0;
                    for (int i = 1; i < GroundObject.amount; i++)
                    {
                        if (worldWideCurrency + 1 * i < worldWideMaxCurrency)
                        {
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }  // this just counts how many be added to the inventory 

                    worldWideCurrency += count;
                    GroundObject.gameObject.GetComponent<GroundItem>().amount = GroundObject.amount - count;
                }
            }
            else
            {
                LocalCurrency[0] += GroundObject.amount;


                if (GroundObject.amount + LocalCurrency[0] <= localCurrencyMax)
                {
                    LocalCurrency[0] += GroundObject.amount;
                }
                else if (1 + LocalCurrency[0] < localCurrencyMax)
                {
                    int count = 0;
                    for (int i = 1; i < GroundObject.amount; i++)
                    {
                        if (LocalCurrency[0] + 1 * i < localCurrencyMax)
                        {
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }  // this just counts how many be added to the inventory 

                    LocalCurrency[0] += count;
                    GroundObject.gameObject.GetComponent<GroundItem>().amount = GroundObject.amount - count;
                }
            }
        }
        else
        {
            // other types of object to add to character
        }
    }

    IEnumerator WaitReact()
    {
        yield return new WaitForSeconds(.3f);

        ableToInteract = true;
    }
    IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(.3f);

        AbleToAttack = true;
    }
    IEnumerator DeathCo()
    {
        yield return new WaitForSeconds(2);

        currentlyDead = false;

        CurrentHealth = maxHealth;
        this.transform.position = lastRestLocation;

        this.GetComponent<SpriteRenderer>().color = Color.white;
        PlayerManager.instance.LoadMasks();
    }
    IEnumerator AttackAn()
    {
        attackArea.AttackShow.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        attackArea.AttackShow.SetActive(false);
    }
}
