using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoundScoreButton : MonoBehaviour {

    public int step = 1;
    private ShowChangeScoreButtons script;
    // Start is called before the first frame update
    void Start() {
        script = transform.parent.gameObject.GetComponent<ShowChangeScoreButtons>();
    }

    // Update is called once per frame
    public void Touch() {
        script.timer.AddTime(script.t);
        GamePlay.UpdateCurrentPlayersScore(step);
    }
}
