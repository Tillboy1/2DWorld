using UnityEngine;

[System.Serializable]
public class OptionsData
{
    // Holds all of our Gameplay data
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
    public bool skillsNavigation;
    public int traversalAssist;
    public bool tutorialAssist;
    public bool weaponSheathing;

    [Header("HUD")]
    public int hudMode;
    public bool compass;
    public bool enemyHealthBars;
    public bool bossHealthBars;
    public bool enemyOffScreenIndicators;
    public bool combatHud;
    public bool gamplayNotifications;

    [Header("Camera")]
    public float horzontalRotationalSpeed;
    public float verticalRotationalSpeed;
    public bool invertHorzontalRotational;
    public bool invertVerticalRotational;

    [Header("Aim Camera")]
    public float aimHorzontalRotationalSpeed;
    public float aimVerticalRotationalSpeed;
    public bool aimAssist;

    [Header("Combat Camera")]
    public bool recenterCameraOnAttack;
    public bool strafeAssist;

    [Header("Audio")]
    public float mainVolLevel;
    public float musicVolLevel;
    public float dialogueVolLevel;
    public float sFXVolLevel;
    public float menuVolLevel;
    public bool subtitles;
    public bool headphonesMode;

    [Header("Video")]
    public float[] screenSize = new float[2];
    public float motionBlur;
    public float filmGrain;
    public int graphicsMode;
    public int[] resolution = new int[2];
    public bool Fullscreen;

    [Header("Accessibility")]
    public bool repeatedButtonPresses;
    public bool chiselDoors;
    public bool holdForSprint;
    public bool stunGrab;
    public int subtitleBackground;
    public bool subtileSpeaker;
    public float ambiantCameraSway;

    [Header("Languages")]
    public string TextLanguage;
    public string SpokenLanguage;
    public bool Subtitles;

    [Header("Controls")]
    public string moveForward;
    public string moveLeft;
    public string moveBackwards;
    public string moveRight;
    public string meleeAttack;
    public string rangedAttack;
    public string interact;
    public string pickUp;
    public string jump;
    public string crouch;
    public string sprint;
    public string inventory;

    public void OptionData(MainMenu menu)
    {
        // Gameplay
        difficulty = menu.seperateScreens[0].GetComponent<GameplaySettings>().difficulty;
        puzzleAimAssist = menu.seperateScreens[0].GetComponent<GameplaySettings>().puzzleAimAssist;
        puzzleTiming = menu.seperateScreens[0].GetComponent<GameplaySettings>().puzzleTiming;
        lockOnCamera = menu.seperateScreens[0].GetComponent<GameplaySettings>().lockOnCamera;
        resetCameraOnAttack = menu.seperateScreens[0].GetComponent<GameplaySettings>().resetCameraOnAttack;

        autoPickUp = menu.seperateScreens[0].GetComponent<GameplaySettings>().autoPickUp;
        menuHolders = menu.seperateScreens[0].GetComponent<GameplaySettings>().menuHolders;
        mini_GameStyle = menu.seperateScreens[0].GetComponent<GameplaySettings>().mini_GameStyle;
        navigationAssist = menu.seperateScreens[0].GetComponent<GameplaySettings>().navigationAssist;
        skillsNavigation = menu.seperateScreens[0].GetComponent<GameplaySettings>().SkillsNavigation;
        traversalAssist = menu.seperateScreens[0].GetComponent<GameplaySettings>().traversalAssist;
        tutorialAssist = menu.seperateScreens[0].GetComponent<GameplaySettings>().tutorialAssist;
        weaponSheathing = menu.seperateScreens[0].GetComponent<GameplaySettings>().weaponSheathing;

        //Hud
        hudMode = menu.seperateScreens[1].GetComponent<HudSettings>().hudMode;
        compass = menu.seperateScreens[1].GetComponent<HudSettings>().compass;
        enemyHealthBars = menu.seperateScreens[1].GetComponent<HudSettings>().enemyHealthBars;
        bossHealthBars = menu.seperateScreens[1].GetComponent<HudSettings>().bossHealthBars;
        enemyOffScreenIndicators = menu.seperateScreens[1].GetComponent<HudSettings>().enemyOffScreenIndicators;
        combatHud = menu.seperateScreens[1].GetComponent<HudSettings>().combatHud;
        gamplayNotifications = menu.seperateScreens[1].GetComponent<HudSettings>().gamplayNotifications;

        //Camera
        horzontalRotationalSpeed = menu.seperateScreens[2].GetComponent<CameraOptions>().horizontalRotateSpeed;
        verticalRotationalSpeed = menu.seperateScreens[2].GetComponent<CameraOptions>().verticalRotateSpeed;
        invertHorzontalRotational = menu.seperateScreens[2].GetComponent<CameraOptions>().invertHorizontalRotate;
        invertVerticalRotational = menu.seperateScreens[2].GetComponent<CameraOptions>().invertVerticalRotate;

        aimHorzontalRotationalSpeed = menu.seperateScreens[2].GetComponent<CameraOptions>().aimHorizontalRotateSpeed;
        aimVerticalRotationalSpeed = menu.seperateScreens[2].GetComponent<CameraOptions>().aimVerticalRotateSpeed;
        aimAssist = menu.seperateScreens[2].GetComponent<CameraOptions>().aimAssist;

        recenterCameraOnAttack = menu.seperateScreens[2].GetComponent<CameraOptions>().recenterCamOnAttack;
        strafeAssist = menu.seperateScreens[2].GetComponent<CameraOptions>().strafeAssist;

        // Audio

        mainVolLevel = menu.seperateScreens[3].GetComponent<AudioSettings>().mainVolume;
        musicVolLevel = menu.seperateScreens[3].GetComponent<AudioSettings>().musicVolume;
        dialogueVolLevel = menu.seperateScreens[3].GetComponent<AudioSettings>().dialogueVolume;
        sFXVolLevel = menu.seperateScreens[3].GetComponent<AudioSettings>().sFXVolume;
        menuVolLevel = menu.seperateScreens[3].GetComponent<AudioSettings>().menuVolume;
        subtitles = menu.seperateScreens[3].GetComponent<AudioSettings>().subtitles;
        headphonesMode = menu.seperateScreens[3].GetComponent<AudioSettings>().headphonesmode;

        // Video
        screenSize[0] = menu.seperateScreens[4].GetComponent<VideoSettings>().CanvasSize.x;
        screenSize[1] = menu.seperateScreens[4].GetComponent<VideoSettings>().CanvasSize.y;
        motionBlur = menu.seperateScreens[4].GetComponent<VideoSettings>().motionBlur;
        filmGrain = menu.seperateScreens[4].GetComponent<VideoSettings>().filmGrain;
        Debug.Log("StuffMissingHere commented out");
        //graphicsMode = menu.seperateScreens[4].GetComponent<VideoSettings>().;
        //resolution[0] = menu.seperateScreens[4].GetComponent<VideoSettings>().;
        Fullscreen = menu.seperateScreens[4].GetComponent<VideoSettings>().fullscreen;



        // Accessibilies
        repeatedButtonPresses = menu.seperateScreens[5].GetComponent<AccessibilityOptions>().repeatedButtonPresses;
        chiselDoors = menu.seperateScreens[5].GetComponent<AccessibilityOptions>().chiselDoors;
        holdForSprint = menu.seperateScreens[5].GetComponent<AccessibilityOptions>().holdForSprint;
        stunGrab = menu.seperateScreens[5].GetComponent<AccessibilityOptions>().stunGrab;
        subtitleBackground = menu.seperateScreens[5].GetComponent<AccessibilityOptions>().subtitleBackground;
        subtileSpeaker = menu.seperateScreens[5].GetComponent<AccessibilityOptions>().subtileSpeaker;
        ambiantCameraSway = menu.seperateScreens[5].GetComponent<AccessibilityOptions>().ambiantCameraSway;

        // Language
        TextLanguage = menu.seperateScreens[6].GetComponent<LanguageSettings>().chosenLanguage.ToString();
        SpokenLanguage = menu.seperateScreens[6].GetComponent<LanguageSettings>().chosenLanguage.ToString();
        Subtitles = menu.seperateScreens[6].GetComponent<LanguageSettings>().UsingSubtitles;

        // Controls
        moveForward = menu.seperateScreens[7].GetComponent<ControlsScreen>().keycodes[0].ToString();
        moveLeft = menu.seperateScreens[7].GetComponent<ControlsScreen>().keycodes[0].ToString();
        moveBackwards = menu.seperateScreens[7].GetComponent<ControlsScreen>().keycodes[0].ToString();
        moveRight = menu.seperateScreens[7].GetComponent<ControlsScreen>().keycodes[0].ToString();
        meleeAttack = menu.seperateScreens[7].GetComponent<ControlsScreen>().keycodes[0].ToString();
        rangedAttack = menu.seperateScreens[7].GetComponent<ControlsScreen>().keycodes[0].ToString();
        interact = menu.seperateScreens[7].GetComponent<ControlsScreen>().keycodes[0].ToString();
        pickUp = menu.seperateScreens[7].GetComponent<ControlsScreen>().keycodes[0].ToString();
        jump = menu.seperateScreens[7].GetComponent<ControlsScreen>().keycodes[0].ToString();
        crouch = menu.seperateScreens[7].GetComponent<ControlsScreen>().keycodes[0].ToString();
        sprint = menu.seperateScreens[7].GetComponent<ControlsScreen>().keycodes[0].ToString();
        inventory = menu.seperateScreens[7].GetComponent<ControlsScreen>().keycodes[0].ToString();
    }   
}       
        
        