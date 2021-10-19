using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject resetPanel;
    void Start()
    {
        FindObjectOfType<AudioManager>().PlaySound("MainTheme3");
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void LoadGameDragon()
    {
        SceneManager.LoadScene("DragonFly");
    }
    public void LoadGameCube ()
    {
        SceneManager.LoadScene("CubeRun");
    }
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        resetPanel.SetActive(false);
    }
    public void ShowPanel()
    {
        resetPanel.SetActive(true);
    }
    public void Close()
    {
        resetPanel.SetActive(false);
    }
    public void ButtonSound()
    {
        FindObjectOfType<AudioManager>().PlaySound("ButtonSound");
    }
}
