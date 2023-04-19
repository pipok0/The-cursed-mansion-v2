using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenu;

    private GameObject player;
    //private GameObject panelSettings;
    private Vector3 startPosition;
   
    void Update()
    {
        
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Touche Échap détectée !");
            if (gameIsPaused)
            {
                Resume();
                Debug.Log("Resume détectée !");
            }
            else
            {
                
                Paused();
                Debug.Log("Pause détectée !");
            }
        }
    }

    public void Paused()
    {
        //PlayerMovement.instance.enabled = false;
        //activer le menu pause c'est à dire l'afficher
        pauseMenu.SetActive(true);
        //arréter le temps
        Time.timeScale = 0;
        //changer le statut du jeu
        gameIsPaused = true;
    }

    

    public void Resume()
    {
        //reglage des problème de saut
        //PlayerMovement.instance.enabled = true;
        //desactiver le menu pause c'est à dire l'afficher
        pauseMenu.SetActive(false);
        //relancer le temps
        Time.timeScale = 1;
        //changer le statut du jeu
        gameIsPaused = false;
    }


    public void RestartGame()
    {
        Resume();
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Menu(GameObject menu)
    {
        Paused();
        menu.SetActive(true);
        
    }

}

