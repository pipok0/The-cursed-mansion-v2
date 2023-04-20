using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinDuNiveau : MonoBehaviour
{
    private Button btnRecommencer;
    private Button btnMainMenu;

    void Start()
    {
        btnRecommencer = GameObject.Find("RestartButton").GetComponent<Button>();
        btnRecommencer.onClick.AddListener(RestartGame);

        btnMainMenu = GameObject.Find("MainMenuButton").GetComponent<Button>();
        btnMainMenu.onClick.AddListener(MainMenu);
    }

    void RestartGame()
    {
        Debug.Log("Vous avez cliqué sur " + btnRecommencer.name);
        SceneManager.LoadScene("Assets/Scenes/SampleScene.unity");
        Inventory.instance.RemoveCoins();
        PlayerHealth.instance.Respawn();
    }
    void MainMenu()
    {
        Debug.Log("Vous avez cliqué sur " + btnMainMenu.name);
        SceneManager.LoadScene("Assets/Scenes/Menu.unity");
    }
}
