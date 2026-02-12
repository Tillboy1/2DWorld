using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class AudioSettings : MonoBehaviour
{
    public AudioMixer mixer;

    public float mainVolume;
    public float musicVolume;
    public float sFXVolume;
    public float dialogueVolume;
    public float menuVolume;

    public bool subtitles;
    public bool headphonesmode;

    public GameObject[] volumeTexts = new GameObject[5];

    public void Start()
    {
        //getting the text for the volumes
        for (int i = 0; i < volumeTexts.Length; i++)
        {
            //Debug.Log(i + ", " + volumeTexts.Length);
            volumeTexts[i] = this.transform.GetChild(3).GetChild(i).GetChild(2).transform.gameObject;
        }

        //finds if there is a saved audio level turns the setting back before player goes into menu
        //also changes the UI (-80 + (PlayerPrefs.GetFloat("masterVol") * 10))
        if (PlayerPrefs.HasKey("masterVol")) { mixer.SetFloat("Master", (-80 + (PlayerPrefs.GetFloat("masterVol") * 10))); volumeTexts[0].GetComponent<TMP_Text>().text = PlayerPrefs.GetFloat("masterVol").ToString(); }
        if (PlayerPrefs.HasKey("musicVol")) { mixer.SetFloat("Music", (-80 + (PlayerPrefs.GetFloat("masterVol") * 10))); volumeTexts[1].GetComponent<TMP_Text>().text = PlayerPrefs.GetFloat("masterVol").ToString(); }
        if (PlayerPrefs.HasKey("sFXVol")) { mixer.SetFloat("SFX", (-80 + (PlayerPrefs.GetFloat("masterVol") * 10))); volumeTexts[2].GetComponent<TMP_Text>().text = PlayerPrefs.GetFloat("masterVol").ToString(); }
        if (PlayerPrefs.HasKey("dialogueVol")) { mixer.SetFloat("Dialogue", (-80 + (PlayerPrefs.GetFloat("masterVol") * 10))); volumeTexts[3].GetComponent<TMP_Text>().text = PlayerPrefs.GetFloat("masterVol").ToString(); }
        if (PlayerPrefs.HasKey("menuVol")) { mixer.SetFloat("Menu", (-80 + (PlayerPrefs.GetFloat("masterVol") * 10))); volumeTexts[4].GetComponent<TMP_Text>().text = PlayerPrefs.GetFloat("masterVol").ToString(); }

        //same again but for the subtitles

        if (PlayerPrefs.HasKey("subtitleActive")) 
        { 
            switch (PlayerPrefs.GetInt("subtitleActive"))
            {
                case 0:
                    subtitles = false;
                    break;
                case 1:
                    subtitles = true;
                    break;
            }
        }

        // same again for the heaphones input

        if (PlayerPrefs.HasKey("headphonesActive"))
        {
            switch (PlayerPrefs.GetInt("headphonesActive"))
            {
                case 0:
                    headphonesmode = false;
                    break;
                case 1:
                    headphonesmode = true;
                    break;
            }
        }
    }

    #region volume settings
    public void MainVolume(float volume)
    {
        mixer.SetFloat("Master", (-80 + (volume * 10)));
        PlayerPrefs.SetFloat("masterVol", volume);
        PlayerPrefs.Save();
        mainVolume = volume;
        volumeTexts[0].GetComponent<TMP_Text>().text = volume.ToString();
    }
    public void MusicVolume(float volume)
    {
        mixer.SetFloat("Music", (-80 + (volume * 10)));
        PlayerPrefs.SetFloat("musicVol", volume);
        PlayerPrefs.Save();
        musicVolume = volume;
        volumeTexts[1].GetComponent<TMP_Text>().text = volume.ToString();
    }
    public void DialogueVolume(float volume)
    {
        mixer.SetFloat("Dialogue", (-80 + (volume * 10)));
        PlayerPrefs.SetFloat("dialogueVol", volume);
        PlayerPrefs.Save();
        dialogueVolume = volume;
        volumeTexts[2].GetComponent<TMP_Text>().text = volume.ToString();
    }
    public void SFXVolume(float volume)
    {
        mixer.SetFloat("SFX", (-80 + (volume * 10)));
        PlayerPrefs.SetFloat("sFXVol", volume);
        PlayerPrefs.Save();
        sFXVolume = volume;
        volumeTexts[3].GetComponent<TMP_Text>().text = volume.ToString();
    }
    public void MenuVolume(float volume)
    {
        mixer.SetFloat("Menu", (-80 + (volume * 10)));
        PlayerPrefs.SetFloat("menuVol", volume);
        PlayerPrefs.Save();
        menuVolume = volume;
        volumeTexts[4].GetComponent<TMP_Text>().text = volume.ToString();
    }
    #endregion

    public void SubtitlesOnOff(int dropInput)
    {
        switch (dropInput)
        {
            case 0:
                subtitles = false;
                PlayerPrefs.SetInt("subtitleActive", 0);
                PlayerPrefs.Save();
                break;
            case 1:
                subtitles = true;
                PlayerPrefs.SetInt("subtitleActive", 1);
                PlayerPrefs.Save();
                break;
        }
    }
    public void HeadphonesOnOff(int dropInput)
    {
        switch (dropInput)
        {
            case 0:
                headphonesmode = false;
                PlayerPrefs.SetInt("headphonesActive", 0);
                PlayerPrefs.Save();
                break;
            case 1:
                headphonesmode = true;
                PlayerPrefs.SetInt("headphonesActive", 1);
                PlayerPrefs.Save();
                break;
        }
    }
}
