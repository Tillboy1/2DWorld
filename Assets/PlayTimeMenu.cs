using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayTimeMenu : MonoBehaviour
{
    public GameObject player;
    public void ResumeGame()
    {
        this.gameObject.SetActive(false);
        player.GetComponent<PlayerStats>().AbleToMove = true;
    }
    public void OpenOptions()
    {

    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
