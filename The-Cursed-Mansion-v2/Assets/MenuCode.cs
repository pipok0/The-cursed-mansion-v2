using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuCode : MonoBehaviour
{
    public string levelToload;
    
    public void StartGame()
    {
        SceneManager.LoadScene(levelToload);
    }
    public void SettingButton()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
