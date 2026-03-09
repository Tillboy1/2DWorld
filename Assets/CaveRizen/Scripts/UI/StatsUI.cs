using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    private PlayerStats PlayerStats;

    public GameObject MaskPrefabs;
    public Sprite BaseMask;
    public Sprite BrokenMask;
    public GameObject TempMaskPrefab;

    List<GameObject> MaskList = new List<GameObject>();
    public GameObject MaskArea;

    public GameObject focusAvalableObj;
    public Slider FocusSlider;

    private void Start()
    {
        PlayerStats = transform.parent.transform.parent.GetComponent<PlayerStats>();

        foreach (Transform Object1 in this.transform)
        {
            foreach(Transform Object2 in Object1.transform)
            {
                if (Object2.gameObject.name == "Masks")
                {
                    MaskArea = Object2.gameObject;
                }
                if (Object2.gameObject.name == "AbilityReady")
                {
                    focusAvalableObj = Object2.gameObject;
                }
            }
            if(Object1.gameObject.name == "Soul Charge")
            {
                FocusSlider = Object1.GetComponent<Slider>();
            }
        }

        LoadMasks();
    }

    public void LoadMasks()
    {
        //remove all orrignal health
        if (MaskList.Count > 0)
        {
            foreach (GameObject mask in MaskList)
            {
                Destroy(mask.gameObject);
            }
        }

        // adding the new health
        for (int i = 0; i < PlayerStats.maxHealth; i++)
        {
            var CurrentMask = Instantiate(MaskPrefabs, MaskArea.transform);
            if(PlayerStats.CurrentHealth > i)
            {
                CurrentMask.GetComponent<Image>().sprite = BaseMask;
            }
            else
            {
                CurrentMask.GetComponent<Image>().sprite = BrokenMask;
            }
            MaskList.Add(CurrentMask);
        }

        // Adding any temp Health
        for (int i = 0; i < PlayerStats.tempHealth; i++)
        {
            var CurrentTempMask = Instantiate(TempMaskPrefab, MaskArea.transform);
            CurrentTempMask.GetComponent<Image>().sprite = BaseMask;
            MaskList.Add(CurrentTempMask);
        }

        MaskList.Reverse();
    }
    public void LoadFocus()
    {
        //FocusSlider.maxValue = PlayerStats.MaxFocus;
        FocusSlider.value = PlayerStats.focusAmount;
    }
}
