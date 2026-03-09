using Newtonsoft.Json.Bson;
using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class PlayerStats : MonoBehaviour
{
    public GameObject TestSpawnLocation;
    public Vector2 lastRestLocation;

    [Header("UI")]
    public GameObject UICanvas;

    public GameObject MenuUI;
    private GameObject BaseLineUI;
    public GameObject LocationUi;
    public GameObject ConvostaionUI;
    public GameObject[] UIScreens;
    public bool UIOpen;

    [Header("Health")]
    public GameObject StatsUI;

    public float CurrentHealth;
    public float maxHealth;
    public int tempHealth;

    public bool interacting;
    private bool ableToInteract = true;

    [Header("Inventory")]
    public InventoryObject inventory;

    public int worldWideCurrency;
    public int worldWideMaxCurrency;

    public int[] LocalCurrency = new int[2];
    public int localCurrencyMax;

    [Header("Combat")]
    public StatsUI statsUI;

    public GameObject attackArea;
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
    public int HealingAmount;
    public bool AbilityReady = false;

    [Header("Shell")]
    public ShellDesigns CurrentShell;
    public ShellDesigns[] ShellsUnlocked;

    private Vector2 m_moveAmt;
    private Rigidbody2D m_rigidbodyb;

    private void Awake()
    {
        int UItempnumber = 0;
        foreach (Transform UiSlot in UICanvas.transform)
        {
            if (UiSlot.gameObject.name == "Baseline")
            {
                BaseLineUI = UiSlot.gameObject;
            }
            else if (UiSlot.gameObject.name == "Basic Stats")
            {
                statsUI = UiSlot.gameObject.GetComponent<StatsUI>();
            }
            else if (UiSlot.gameObject.name == "Location UI")
            {
                LocationUi = UiSlot.gameObject;
            }
            else if (UiSlot.gameObject.name == "Basic Stats")
            {
                StatsUI = UiSlot.gameObject;
            }
            else if (UiSlot.gameObject.name == "Convosation UI")
            {
                ConvostaionUI = UiSlot.gameObject;
            }
            else if (UiSlot.gameObject.name == "Menu")
            {
                MenuUI = UiSlot.gameObject;
                MenuUI.GetComponent<PlayTimeMenu>().player = this.gameObject;
            }
            else
            {
                UIScreens[UItempnumber] = UiSlot.gameObject;
                UItempnumber++;
            }
        }

        m_rigidbodyb = GetComponent<Rigidbody2D>();
        //HealthHolder = StatsUI.transform.GetChild(0).GetChild(1).gameObject;
        /*
        foreach (Transform masks in HealthHolder.transform)
        {
            MaskUI[HealthHolder.transform.childCount] = masks.gameObject;
        }
        */

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
            BaseLineUI.SetActive(true);
            UIScreens[3].gameObject.SetActive(true);

            AbleToMove = false;
        }
        else
        {
            UIOpen = false;
            BaseLineUI.SetActive(false);
            for (int i = 0; i < UIScreens.Length; i++)
            {
                UIScreens[i].gameObject.SetActive(false);
            }
            AbleToMove = true;
        }
    }
    public void CharacterMenuBTN(InputAction.CallbackContext context)
    {
        if (!UIOpen)
        {
            UIOpen = true;
            BaseLineUI.SetActive(true);
            UIScreens[0].gameObject.SetActive(true);

            AbleToMove = false;
        }
        else
        {
            UIOpen = false;
            BaseLineUI.SetActive(false);
            for (int i = 0; i < UIScreens.Length; i++)
            {
                UIScreens[i].gameObject.SetActive(false);
            }
            AbleToMove = true;
        }

    }
    public void OpenMenu(InputAction.CallbackContext context)
    {
        MenuUI.SetActive(true);
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

                    if (focusAmount >= 70)
                    {
                        AbilityReady = true;
                    }
                    statsUI.LoadFocus();

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
    }
    public void TakeDamage(float damage)
    {
        if (CurrentHealth - damage > 0)
        {
            CurrentHealth -= damage;
            statsUI.LoadMasks();
        }
        else
        {
            CurrentHealth = 0;
            statsUI.LoadMasks();
            Die();
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

        }



        /* From Old Script

        if (item && item.Item.Weight * amount < CharacterSheet.Instance.CarryingWeight && CharacterSheet.Instance.CarryingWeight > CharacterSheet.Instance.Currentcarrying) // to take all items and remove the items
        {
            inventory.AddItem(new Item(item.Item), amount);
            CharacterSheet.Instance.Currentcarrying += item.Item.Weight * amount;
            Destroy(objectToPickUp.gameObject);
        }
        else if (item && item.Item.Weight < CharacterSheet.Instance.CarryingWeight && CharacterSheet.Instance.CarryingWeight > CharacterSheet.Instance.Currentcarrying) // incase all of them cant be added at once
        {
            int count = 0;
            for (int i = 1; i < amount; i++)
            {
                if (item.Item.Weight * i < CharacterSheet.Instance.CarryingWeight)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }  // this just counts how many be added to the inventory 

            inventory.AddItem(new Item(item.Item), count);
            CharacterSheet.Instance.Currentcarrying += item.Item.Weight * count;
            GroundObject.gameObject.GetComponent<Grounditem>().amount = amount - count;
        }
        else
        {
            Debug.Log("Take none");
        }
        */
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
        statsUI.LoadMasks();
    }
}
