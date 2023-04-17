using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenu;
    private Button btnRejouer;
    private GameObject player;
    private Vector3 startPosition;

    void Start()
    {
        btnRejouer = GameObject.Find("RetryButton").GetComponent<Button>();
        
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = player.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Touche Échap détectée !");
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
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

        // Ajouter la méthode RestartGame à l'événement onClick du bouton RetryButton
        btnRejouer.onClick.AddListener(RestartGame);
    }

    public void RestartGame()
    {
       
        // changer le statut du jeu
        gameIsPaused = false;

        // réinitialiser la position du joueur
        player.transform.position = startPosition;

        // réactiver le mouvement du joueur
        //PlayerMovement.instance.enabled = true;

        // relancer le temps
        Time.timeScale = 1;

        // désactiver le menu pause
        pauseMenu.SetActive(false);
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
}
