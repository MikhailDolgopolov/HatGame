using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNumberOfPlayers : MonoBehaviour {
    public int step;
    void Start()
    {
        
    }

    public void Change() {
        switch (step) {
            case 1:
                PlayerCreator.CreatePlayer();
                break;
            case -1:
                PlayerCreator.RemovePlayer();
                break;
        }
    }
}
