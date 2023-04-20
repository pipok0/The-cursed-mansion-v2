using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class changeScore : MonoBehaviour
{
    public TextMeshProUGUI score;

    private void Start()
    {
        score.SetText("Score:" + Inventory.instance.coinsCountText.text);
    }
}