using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    public GameObject PlayerScore;
    private RectTransform myRect;
    private RectTransform startTransform;
    // Start is called before the first frame update
    void Start()
    {
        startTransform = PlayerScore.GetComponent<RectTransform>() as RectTransform;
        myRect = gameObject.GetComponent<RectTransform>() as RectTransform;
        myRect.sizeDelta = new Vector2(myRect.sizeDelta.x, (startTransform.sizeDelta.y + 7) * GameSettings.numberOfPlayers + 10f);
        SpawnScores();
    }
    void SpawnScores()
    {
        for(int i = 0; i < GameSettings.numberOfPlayers; i++)
        {
            SpawnScore(i);
        }
    }
    void SpawnScore(int i)
    {
        GameObject onePlayer = Instantiate(PlayerScore) as GameObject;
        onePlayer.transform.SetParent(gameObject.transform);
        RectTransform hisRect = onePlayer.GetComponent<RectTransform>() as RectTransform;
        hisRect.localScale = Vector3.one;
        onePlayer.GetComponent<PlayerResultPanel>().SetScorePanel(GameSettings.sortedPlayers[i]);
    }
}
