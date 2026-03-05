using UnityEngine;

public class GameplaySettings : MonoBehaviour
{
    // This would be removed in the build of the game for performance but good to test to find optimum game balance
    [Header("Edditor")]
    public float difficultyEasySet;

    // Holds all of our data :D
    [Header("GamePlay")]
    public float difficulty;
    public bool puzzleAimAssist;
    public float puzzleTiming;
    public int lockOnCamera;
    public int resetCameraOnAttack;

    [Header("PlayStyle")]
    public int autoPickUp;
    public int menuHolders;
    public int mini_GameStyle;
    public bool navigationAssist;
    public bool SkillsNavigation;
    public int traversalAssist;
    public bool tutorialAssist;
    public bool weaponSheathing;

    #region Gameplay
    /// <summary>
    /// Changes the variable of difficulty
    /// </summary>
    /// <param name="dropInput">int changes level of difficulty including 0-3</param>
    public void SetDifficulty(int dropInput)
    {
        switch (dropInput)
        {
            case 0:
                difficulty = difficultyEasySet;
                PlayerPrefs.SetFloat("difficultyFloat", difficulty);
                PlayerPrefs.Save();
                break;
            default:
                difficulty = dropInput;
                PlayerPrefs.SetFloat("difficultyFloat", difficulty);
                PlayerPrefs.Save();
                break;
        }
    }
    public void SetPuzzleAimAssist(int dropInput)
    {
        switch (dropInput)
        {
            case 0:
                puzzleAimAssist = false;
                PlayerPrefs.SetInt("puzzleAimAssistBool", dropInput);
                PlayerPrefs.Save();
                break;
            default:
                puzzleAimAssist = true;
                PlayerPrefs.SetInt("puzzleAimAssistBool", dropInput);
                PlayerPrefs.Save();
                break;
        }
    }
    public void SetPuzzleTiming(int dropInput)
    {
        switch (dropInput)
        {
            case 0:
                puzzleTiming = difficultyEasySet;
                PlayerPrefs.SetFloat("puzzleTimeFloat", dropInput);
                PlayerPrefs.Save();
                break;
            default:
                puzzleTiming = dropInput;
                PlayerPrefs.SetFloat("puzzleTimeFloat", dropInput);
                PlayerPrefs.Save();
                break;
        }
    }
    public void SetLockOnCamera(int dropInput)
    {
        lockOnCamera = dropInput;
        PlayerPrefs.SetInt("resetCamOnAttackInt", dropInput);
        PlayerPrefs.Save();
    }
    public void SetResetCamOnAttack(int dropInput)
    {
        resetCameraOnAttack = dropInput;
        PlayerPrefs.SetInt("resetCamOnAttackInt", dropInput);
        PlayerPrefs.Save();
    }
    #endregion
    #region
    public void SetAutoPickup(int dropInput)
    {
        autoPickUp = dropInput;
        PlayerPrefs.SetInt("autoPickUpInt", dropInput);
        PlayerPrefs.Save();
    }
    public void SetMenuHold(int dropInput)
    {
        menuHolders = dropInput;
        PlayerPrefs.SetInt("menuHoldInt", dropInput);
        PlayerPrefs.Save();
    }
    public void SetMiniGameStyle(int dropInput)
    {
        mini_GameStyle = dropInput;
        PlayerPrefs.SetInt("miniGameStyleInt", dropInput);
        PlayerPrefs.Save();
    }
    public void SetNavigationAssist(int dropInput)
    {
        switch (dropInput)
        {
            case 0:
                navigationAssist = false;
                PlayerPrefs.SetFloat("strafeAssistBool", dropInput);
                PlayerPrefs.Save();
                break;
            default:
                navigationAssist = true;
                PlayerPrefs.SetFloat("strafeAssistBool", dropInput);
                PlayerPrefs.Save();
                break;
        }
    }
    public void SetSkillsNavigation(int dropInput)
    {
        switch (dropInput)
        {
            case 0:
                SkillsNavigation = false;
                PlayerPrefs.SetFloat("skillsNavigationBool", dropInput);
                PlayerPrefs.Save();
                break;
            default:
                SkillsNavigation = true;
                PlayerPrefs.SetFloat("skillsNavigationBool", dropInput);
                PlayerPrefs.Save();
                break;
        }
    }
    public void SetTraversalAssist(int dropInput)
    {
        traversalAssist = dropInput;
        PlayerPrefs.SetInt("traversalAssistInt", dropInput);
        PlayerPrefs.Save();
    }
    public void SetTutorial(int dropInput)
    {
        switch (dropInput)
        {
            case 0:
                tutorialAssist = false;
                PlayerPrefs.SetInt("tutorialAssistBool", dropInput);
                PlayerPrefs.Save();
                break;
            default:
                tutorialAssist = true;
                PlayerPrefs.SetInt("tutorialAssistBool", dropInput);
                PlayerPrefs.Save();
                break;
        }
    }
    public void SetWeaponSheathing(int dropInput)
    {
        switch (dropInput)
        {
            case 0:
                weaponSheathing = false;
                PlayerPrefs.SetInt("weaponSheathingBool", dropInput);
                PlayerPrefs.Save();
                break;
            default:
                weaponSheathing = true;
                PlayerPrefs.SetInt("weaponSheathingBool", dropInput);
                PlayerPrefs.Save();
                break;
        }
    }
    #endregion
}
