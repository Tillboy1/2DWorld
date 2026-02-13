using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VideoSettings : MonoBehaviour
{
    public TMP_Dropdown resalutionDropdown;
    public Resolution[] resolutions;

    //Settings saved 
    public float filmGrain;
    public float motionBlur;

    public Vector2 CanvasSize;
    public bool fullscreen;

    void Start()
    {
        // Finds all possible Resalutions and adds them to a list to use later
        resolutions = Screen.resolutions;
        resalutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                //Finds the used Resalution and applies it to the game
                currentResolutionIndex = i;
            }
        }

        // Adds all possible resalutions to dropdown and makes UI detect what is being used
        resalutionDropdown.AddOptions(options);
        resalutionDropdown.value = currentResolutionIndex;
        resalutionDropdown.RefreshShownValue();
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  Display

    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }


    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  Display

    public void MotionBlur(float Value)
    {
        PlayerPrefs.SetFloat("MBlur", Value);
    }
    public void FilmGrain(float Value)
    {
        PlayerPrefs.SetFloat("FGrain", Value);
    }
    public void ChangeVisualSettings(int settinglevel)
    {
        QualitySettings.SetQualityLevel(settinglevel);
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  Window Size

    public void SetFullScreen()
    {
        if (Screen.fullScreen)
        {
            Screen.fullScreen = false;
            fullscreen = false;
        }
        else
        {
            Screen.fullScreen = true;
            fullscreen = true;
        }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - Render Scale
    public void ChangeRenderScale(float scale)
    {
        UniversalRenderPipelineAsset pipeline = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;
    }




    
}
