
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    #region Variables
    // mainMenu
    public GameObject BTNStart => this.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
    public GameObject BTNLoad => this.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
    public GameObject BTNSettings => this.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
    public GameObject BTNQuit => this.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject;

    public GameObject[] seperateScreens;

    

    //
    [Header("Savefile")]
    [Tooltip("the number of the file able to be open")]
    static int SaveSlotChoosen;
    public GameObject[] FileBTN;

    #endregion

    public void Save()
    {
        SaveSystem.Save();
    }

    public void NewGame()
    {
        Debug.Log("Creating Game File");
    }
    public void ChooseFile(int selected)
    {
        for (int i = 0; i < FileBTN.Length; i++)
        {
            FileBTN[i].GetComponent<Image>().color = new Color(1, 1, 1);
        }
        FileBTN[selected].GetComponent<Image>().color = new Color(0, 1, 0);

        SaveSlotChoosen = selected;
    }
    public void LoadGame()
    {
        Debug.Log("Load Game");
    }
    public void RemoveSave()
    {
        Debug.Log("removed data for " + SaveSlotChoosen);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
