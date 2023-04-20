using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeScore : MonoBehaviour
{
    public Text score; 

    private void Update()
    {
        score.text = "Score: " + Inventory.instance.coinsCountText;
    }
}
