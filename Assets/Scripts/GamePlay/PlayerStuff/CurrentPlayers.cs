using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentPlayers : MonoBehaviour
{
    private TextMeshProUGUI giver;
    private TextMeshProUGUI receiver;
    void Start()
    {
        giver = gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        receiver = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        //GamePlay.OnNewRound += SetPlayers;
    }
    
    public void SetPlayers() {
        var pair = GamePlay.currentPlayers;
        giver.text = pair[0].name;
        receiver.text = pair[1].name;
    }
}
