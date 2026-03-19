using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public List<PlayerStats> allPlayers = new List<PlayerStats>();

    [Header("UI")]
    public GameObject UICanvas;

    public GameObject SingleplayerStatsUI;
    public GameObject MultiplayerStatsUI;

    public GameObject MultiplayerUI;
    GameObject SplitScreenUI;

    [Header("Prefab Icons")]
    public GameObject MaskPrefabs;
    public Sprite BaseMask;
    public Sprite BrokenMask;
    public GameObject TempMaskPrefab;

    [Header("Stats Singleplayer")]
    public GameObject MaskAreaSinglePlayer;
    List<GameObject> MaskListPlay1 = new List<GameObject>();

    public GameObject focusAvalableObjSingleplayer;
    public Slider FocusSliderSingleplayer;

    [Header("Stats Multiplayer")]
    public GameObject MaskAreaMultiPlayer;
    List<GameObject> MaskListPlay2 = new List<GameObject>();

    public GameObject focusAvalableObjMultiplayer;
    public Slider FocusSliderMultiplayer;

    [Header("SingleplayerMenu")]
    public GameObject LocationUi;
    public GameObject ConvostaionUI;
    public GameObject PTMenuUI;

    public GameObject BaseLineUI;
    GameObject[] UIScreens = new GameObject[4];

    [Header("Dialoge")]
    private TMP_Text ConvoName;
    private TMP_Text Convotext;

    private int Parlength;
    private string p;
    private string N;

    private Queue<string> Names = new Queue<string>();
    private Queue<string> paragraphs = new Queue<string>();
    private bool convosationEnded;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }


        int UItempnumber = 0;
        foreach (Transform UiSlot in UICanvas.transform)
        {
            if (UiSlot.gameObject.name == "Location UI")
            {
                LocationUi = UiSlot.gameObject;
            }
            else if (UiSlot.gameObject.name == "Convosation UI")
            {
                ConvostaionUI = UiSlot.gameObject;
            }
            else if (UiSlot.gameObject.name == "Menu")
            {
                PTMenuUI = UiSlot.gameObject;
            }
            else if (UiSlot.gameObject.name == "Baseline")
            {
                BaseLineUI = UiSlot.gameObject;
            }
            else if (UiSlot.gameObject.name != "Basic Stats" && UiSlot.gameObject.name != "Multiplayer")
            {
                UIScreens[UItempnumber] = UiSlot.gameObject;
                UItempnumber++;
            }
        }
    }

    public void Start()
    {
        // Get UI Components
        foreach (Transform Objects in MultiplayerUI.transform)
        {
            if(Objects.gameObject.name == "Middle Icon")
            {
                SplitScreenUI = Objects.gameObject;
            }
        }

        // Dialog
        foreach (Transform objects in ConvostaionUI.transform)
        {
            if(objects.gameObject.name == "Character Name")
            {
                ConvoName = objects.gameObject.GetComponent<TMP_Text>();
            }
            else if (objects.gameObject.name == "Convosation")
            {
                Convotext = objects.gameObject.GetComponent<TMP_Text>();
            }
        }

        // Singleplayer
        foreach (Transform Object1 in SingleplayerStatsUI.transform)
        {
            foreach (Transform Object2 in Object1.transform)
            {
                if (Object2.gameObject.name == "Masks")
                {
                    MaskAreaSinglePlayer = Object2.gameObject;
                }
                if (Object2.gameObject.name == "AbilityReady")
                {
                    focusAvalableObjSingleplayer = Object2.gameObject;
                }
            }
            if (Object1.gameObject.name == "Soul Charge")
            {
                FocusSliderSingleplayer = Object1.GetComponent<Slider>();
            }
        }

        // Multiplayer
        foreach (Transform Object1 in MultiplayerStatsUI.transform)
        {
            foreach (Transform Object2 in Object1.transform)
            {
                if (Object2.gameObject.name == "Masks")
                {
                    MaskAreaMultiPlayer = Object2.gameObject;
                }
                if (Object2.gameObject.name == "AbilityReady")
                {
                    focusAvalableObjMultiplayer = Object2.gameObject;
                }
            }
            if (Object1.gameObject.name == "Soul Charge")
            {
                FocusSliderMultiplayer = Object1.GetComponent<Slider>();
            }
        }

        CheckUIRequired();
    }

    public void CheckUIRequired()
    {
        if (allPlayers.Count <= 1)
        {
            MultiplayerUI.SetActive(false);
        }
        else
        {
            MultiplayerUI.SetActive(true);

            if (CameraManager.instance.isCameraSplit)
            {
                SplitScreenUI.SetActive(true);
            }
            else
            {
                SplitScreenUI.SetActive(false);
            }
        }
    }

    #region PlayerStats
    public void LoadMasks()
    {
        //remove all orrignal health
        if (MaskListPlay1.Count > 0)
        {
            foreach (GameObject mask in MaskListPlay1)
            {
                Destroy(mask.gameObject);
            }
        }
        if (MaskListPlay2.Count > 0)
        {
            foreach (GameObject mask in MaskListPlay2)
            {
                Destroy(mask.gameObject);
            }
        }

        for (int i = 0; i < allPlayers.Count; i++)
        {
            if (i == 0)
            {
                // adding the new health
                for (int p = 0; p < allPlayers[0].GetComponent<PlayerStats>().maxHealth; p++)
                {
                    var CurrentMask = Instantiate(MaskPrefabs, MaskAreaSinglePlayer.transform);
                    if (allPlayers[0].GetComponent<PlayerStats>().CurrentHealth > p)
                    {
                        CurrentMask.GetComponent<Image>().sprite = BaseMask;
                    }
                    else
                    {
                        CurrentMask.GetComponent<Image>().sprite = BrokenMask;
                    }
                    MaskListPlay1.Add(CurrentMask);
                }


                // Adding any temp Health
                for (int p = 0; p < allPlayers[0].GetComponent<PlayerStats>().tempHealth; p++)
                {
                    var CurrentTempMask = Instantiate(TempMaskPrefab, MaskAreaSinglePlayer.transform);
                    CurrentTempMask.GetComponent<Image>().sprite = BaseMask;
                    MaskListPlay1.Add(CurrentTempMask);
                }
            }
            else if (i == 1)
            {
                Debug.Log("Multiplayer Health");
                // adding the new health
                for (int l = 0; l < allPlayers[1].GetComponent<PlayerStats>().maxHealth; l++)
                {
                    var CurrentMask = Instantiate(MaskPrefabs, MaskAreaMultiPlayer.transform);
                    if (allPlayers[1].GetComponent<PlayerStats>().CurrentHealth > l)
                    {
                        CurrentMask.GetComponent<Image>().sprite = BaseMask;
                    }
                    else
                    {
                        CurrentMask.GetComponent<Image>().sprite = BrokenMask;
                    }
                    MaskListPlay2.Add(CurrentMask);
                }


                // Adding any temp Health
                for (int l = 0; l < allPlayers[1].GetComponent<PlayerStats>().tempHealth; l++)
                {
                    var CurrentTempMask = Instantiate(TempMaskPrefab, MaskAreaMultiPlayer.transform);
                    CurrentTempMask.GetComponent<Image>().sprite = BaseMask;
                    MaskListPlay2.Add(CurrentTempMask);
                }
            }
        }

        MaskListPlay1.Reverse();
        MaskListPlay2.Reverse();
    }
    public void LoadFocus()
    {
        if (allPlayers.Count == 1)
        {
            //FocusSlider.maxValue = PlayerStats.MaxFocus;
            FocusSliderSingleplayer.value = allPlayers[0].GetComponent<PlayerStats>().focusAmount;
        }
        else if (allPlayers.Count == 2)
        {
            FocusSliderSingleplayer.value = allPlayers[0].GetComponent<PlayerStats>().focusAmount;
            FocusSliderSingleplayer.value = allPlayers[1].GetComponent<PlayerStats>().focusAmount;
        }
    }
    #endregion
    #region playerUIinteractions

    public void CharacterMenu()
    {
        BaseLineUI.SetActive(true);
        UIScreens[0].gameObject.SetActive(true);
    }

    public void Map()
    {
        BaseLineUI.SetActive(true);
        UIScreens[3].gameObject.SetActive(true);
    }
    public void Menu(GameObject PlayerObj)
    {
        PTMenuUI.SetActive(true);
        PTMenuUI.GetComponent<PlayTimeMenu>().player = PlayerObj.gameObject;
    }

    public void CloseUI()
    {
        BaseLineUI.SetActive(false);
        for (int i = 0; i < UIScreens.Length; i++)
        {
            UIScreens[i].gameObject.SetActive(false);
        }
    }

    public void EnteringNewArea(string area)
    {

        LocationUi.GetComponentInChildren<TMP_Text>().text = area;
        StartCoroutine(AreaScreen());
    }
    #endregion

    //public void StartConvosation(ConvosationDialogue Dialogue)
    //{
    //    ConvostaionUI.SetActive(true);
    //
    //    Displaynextparagraph(Dialogue);
    //}
    public void Displaynextparagraph(ConvosationDialogue Dialogue)
    {
        if (paragraphs.Count == 0)
        {
            if (!convosationEnded)
            {
                // start convo
                StartConvosation(Dialogue);
            }

            else
            {
                // end the convosation
                EndConvosation(Dialogue);
                ConvostaionUI.SetActive(false);
                return;
            }
        }

        // if something in the queue
        N = Names.Dequeue();
        p = paragraphs.Dequeue();

        //Update Convisation text
        ConvoName.text = N;
        Convotext.text = p;
        

        if (paragraphs.Count == 0)
        {
            convosationEnded = true;
        }
    }

    public void StartConvosation(ConvosationDialogue Dialogue)
    {
        Debug.Log("Starting convo");
        if (!ConvostaionUI.activeSelf)
        {
            ConvostaionUI.SetActive(true);
        }

        ConvoName.text = Dialogue.Convosation[0].SpeakerName;

        // Gets the whole convosation from all characters talking
        for (int i = 0; i < Dialogue.Convosation.Length; i++)
        {
            // Gets each characters paragraphs
            for (int u = 0; u < Dialogue.Convosation[i].Description.Length; u++)
            {
                Names.Enqueue(Dialogue.Convosation[i].SpeakerName);
                paragraphs.Enqueue(Dialogue.Convosation[i].Description[u]);
            }
        }
    }

    private void EndConvosation(ConvosationDialogue Dialogue)
    {
        //Clear the queue

        convosationEnded = false;
        ConvostaionUI.SetActive(false);

        if (!Dialogue.RepeatedConvisation)
        {
            Dialogue.convosationAllowed = false;
        }
    }

    public void PlayerJoined(PlayerInput player)
    {
        PlayerStats LocalPlayer;
        if (player.TryGetComponent<PlayerStats>(out LocalPlayer))
        {
            allPlayers.Add(LocalPlayer);
        }


        CheckUIRequired();
        LoadMasks();
    }
    public void PlayerLeft(PlayerInput player)
    {
        PlayerStats LocalPlayer;
        if (player.TryGetComponent<PlayerStats>(out LocalPlayer))
        {
            if (allPlayers.Contains(LocalPlayer))
            {
                allPlayers.Remove(LocalPlayer);
            }
        }
        CheckUIRequired();
    }

    IEnumerator AreaScreen()
    {
        yield return new WaitForSeconds(.2f);
        LocationUi.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        LocationUi.SetActive(false);
    }
}
