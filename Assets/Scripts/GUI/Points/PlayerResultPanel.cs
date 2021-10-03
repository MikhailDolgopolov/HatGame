using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerResultPanel : MonoBehaviour
{
    private TextMeshProUGUI playerName;
    private TextMeshProUGUI score;
    void Awake()
    {
        playerName = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        score = gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    public void SetScorePanel(Player p)
    {
        playerName.text = p.name;
        score.text = p.points.ToString();
    }
}
