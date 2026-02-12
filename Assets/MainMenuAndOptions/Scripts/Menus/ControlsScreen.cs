using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using TMPro;

public class ControlsScreen : MonoBehaviour
{
    string TempString;

    [Tooltip("place to save Current keybinds")]
    public Transform Controls_Holdler;
    public GameObject[] controltexts;
    public KeyCode[] keycodes = new KeyCode[12];
    bool WaitingForEvent;
    KeyCode newKey;
    Event KeyEvent;

    public void Awake()
    {
        controltexts = new GameObject[keycodes.Length];
        int TempCount = 0;

        foreach (Transform child in Controls_Holdler)
        {
            controltexts[TempCount] = child.gameObject.transform.GetChild(1).GetChild(0).gameObject;
            TempCount++;
        }

        for (int i = 0; i < controltexts.Length; i++)
        {
            controltexts[i].GetComponent<TMP_Text>().text = keycodes[i].ToString();
        }
    }

    public void ChangeKeybinds(string UseName)
    {
        //gets inputed key to be used later
        WaitingForEvent = true;
        TempString = UseName;
    }

    private void Keychange()
    {
        switch (TempString)
        {
            case "Move Forward":
                keycodes[0] = newKey;
                break;
            case "Move Left":
                keycodes[1] = newKey;
                break;
            case "Move Backwards":
                keycodes[2] = newKey;
                break;
            case "Move Right":
                keycodes[3] = newKey;
                break;
            case "Melee Attack":
                keycodes[4] = newKey;
                break;
            case "Ranged Attack":
                keycodes[5] = newKey;
                break;
            case "Interact":
                keycodes[6] = newKey;
                break;
            case "Pickup":
                keycodes[7] = newKey;
                break;
            case "Jump":
                keycodes[8] = newKey;
                break;
            case "Crouch":
                keycodes[9] = newKey;
                break;
            case "Sprint":
                keycodes[10] = newKey;
                break;
            case "Inventory":
                keycodes[11] = newKey;
                break;
        }

        KeyBindLoad();
    }

    /// <summary>
    /// changes the text on the button UI to show the current key to click to do the stated activity
    /// </summary>
    public void KeyBindLoad() // changes UI TEXT
    {
        //Transform KeybindsScreen = this.transform.GetChild(1).transform.GetChild(3).transform.GetChild(1).transform;

        for (int i = 0; i < controltexts.Length; i++)
        {
            controltexts[i].GetComponent<TMP_Text>().text = keycodes[i].ToString();
        }

        #region KeyToText
        //KeybindList[0].transform.GetChild(0).GetComponent<Text>().text = Player.GetComponent<PlayerMovement>().jumpkey.ToString();
        //KeybindList[1].transform.GetChild(0).GetComponent<Text>().text = Player.GetComponent<PlayerMovement>().sprintkey.ToString();
        //KeybindList[2].transform.GetChild(0).GetComponent<Text>().text = Player.GetComponent<PlayerMovement>().crouchkey.ToString();
        //KeybindList[3].transform.GetChild(0).GetComponent<Text>().text = Player.GetComponent<SelectionManager>().interactkey.ToString();
        //KeybindList[4].transform.GetChild(0).GetComponent<Text>().text = Player.GetComponent<SelectionManager>().Pickupkey.ToString();
        //KeybindList[5].transform.GetChild(0).GetComponent<Text>().text = Manager.transform.GetChild(1).GetComponent<BasicVoice>().voiceKey.ToString();
        //KeybindList[6].transform.GetChild(0).GetComponent<Text>().text = Manager.transform.GetChild(1).GetComponent<BasicVoice>().FalsevoiceKey.ToString();
        //KeybindList[7].transform.GetChild(0).GetComponent<Text>().text = Player.GetComponent<Player>().InventoryKey.ToString();
        //KeybindList[8].transform.GetChild(0).GetComponent<Text>().text = Player.GetComponent<Player>().CharacterSheetKey.ToString();
        //KeybindList[9].transform.GetChild(0).GetComponent<Text>().text = Player.GetComponent<Player>().QuickEquipKey.ToString();
        //KeybindList[10].transform.GetChild(0).GetComponent<Text>().text = Player.GetComponent<Player>().GoToMenuKey.ToString();
        //KeybindList[11].transform.GetChild(0).GetComponent<Text>().text = Player.GetComponent<Player>().CloseScreensKey.ToString();
        #endregion
    }


    /// <summary>
    /// Finds the a event of any key being pressed if the button is pressed and removes the all keys to a selected button if it clicks the escape key so it is saved only for going to menu
    /// </summary>
    private void OnGUI()
    {
        KeyEvent = Event.current;

        if (KeyEvent.isKey && WaitingForEvent)
        {
            if (KeyEvent.keyCode == KeyCode.Escape)
            {
                newKey = KeyCode.None;
            }
            else
            {
                newKey = KeyEvent.keyCode;
            }
            WaitingForEvent = false;
            Keychange();
        }
    }
}
