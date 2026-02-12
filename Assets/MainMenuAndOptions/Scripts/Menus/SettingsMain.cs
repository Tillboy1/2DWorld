using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class SettingsMain : MonoBehaviour
{
    static SettingsMain instance;
    public GameObject mainMenuScreen;

    public GameObject[] screensHolder = new GameObject[9];

    void Start()
    {
        for (int i = 0; i < transform.Find("Screens").childCount; i++)
        {
            screensHolder[i] = transform.Find("Screens").GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenuScreen.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    public void CloseScreens()
    {
        for (int i = 0; i < 9; i++)
        {
            screensHolder[i].gameObject.SetActive(false);
        }
    }
}