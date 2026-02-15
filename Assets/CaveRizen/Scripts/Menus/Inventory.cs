using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    [Header("ScreenData")]
    public bool Inventoryopen;
    public bool isGoingLeft;
    public bool isGoingRight;

    public GameObject ScreenLeft;
    public GameObject ScreenRight;

    [Header("Objects")]
    public int Currency;
    public List<InventoryObject> inventoryObjects;


    public void Update()
    {
        if (Inventoryopen && isGoingLeft)
        {
            ScreenLeft.SetActive(true);
            Inventoryopen = false;
            isGoingLeft = false;
            this.gameObject.SetActive(false);
        }
        else if (Inventoryopen && isGoingRight)
        {
            ScreenRight.SetActive(true);
            Inventoryopen = false;
            isGoingRight = false;
            this.gameObject.SetActive(false);
        }
    }

    public void GoingLeft(InputAction.CallbackContext context)
    {
        isGoingLeft = true;
    }
    public void GoingRight(InputAction.CallbackContext context)
    {
        isGoingRight = true;
    }
}
