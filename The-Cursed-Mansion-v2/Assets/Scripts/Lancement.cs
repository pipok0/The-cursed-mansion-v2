using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lancement : MonoBehaviour
{
    private Button btnJouer;
    private Button btnQuitter;
    private Button btnOption;
    private Button btnCredit;
    private GameObject panelSettings;
    

    void Start()
    {
        panelSettings = GameObject.Find("PanelSettings");
        panelSettings.SetActive(false);

        btnJouer = GameObject.Find("JouerButton").GetComponent<Button>();
        btnJouer.onClick.AddListener(StartGame);

        btnQuitter = GameObject.Find("QuitterButton").GetComponent<Button>();
        btnQuitter.onClick.AddListener(QuitGame);

        btnOption = GameObject.Find("OptionButton").GetComponent<Button>();
        btnOption.onClick.AddListener(Option);

        btnCredit = GameObject.Find("CreditButton").GetComponent<Button>();
        btnCredit.onClick.AddListener(Credit);
    }

    void StartGame()
    {
        Debug.Log("Vous avez cliqué sur " + btnJouer.name);
        SceneManager.LoadScene("Assets/Scenes/SampleScene.unity");
    }
    void QuitGame()
    {
        Debug.Log("Vous avez cliqué sur " + btnQuitter.name);
        Application.Quit();
    }
    void Option()
    {
        Debug.Log("Vous avez cliqué sur " + btnOption.name);
        panelSettings.SetActive(true);
    }
    void Credit()
    {
        Debug.Log("Vous avez cliqué sur " + btnCredit.name);
        SceneManager.LoadScene("Credit");
    }
}
