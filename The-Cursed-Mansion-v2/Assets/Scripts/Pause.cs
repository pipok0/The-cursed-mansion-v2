using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject panel;
    void Start()
    {
        panel = GameObject.Find("PanelPause");
        panel.SetActive(false);
       
    }

   void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Touche Échap détectée !");
            panel.SetActive(true); 
        }
    }
}
