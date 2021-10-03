using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreator : MonoBehaviour
{
    public static PlayerCreator PC;
    public GameObject inputPlayer;
    private RectTransform startTransform;
    private RectTransform myRect;

    public static int playersCreated = 1;
    void Start() {
        PC = this;
        startTransform = gameObject.GetComponentInChildren<RectTransform>();
        myRect = gameObject.GetComponent<RectTransform>();
    }

    public static void CreatePlayer() {
        AddChild(playersCreated);
        playersCreated += 1;
    }

    public static void RemovePlayer() {
        if (playersCreated == 1) return;
        GameSettings.RemovePlayer(playersCreated-1);
        Destroy(PC.myRect.GetChild(playersCreated - 1).gameObject);
        playersCreated -= 1;
    }
    
    static void AddChild(int num)
    {
        GameObject New = Instantiate(PC.inputPlayer) as GameObject;
        New.name = "Player " + (num+1).ToString();
        New.transform.SetParent(PC.myRect, false);
        PC.myRect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top,0, 
            (playersCreated+1)*80+playersCreated*10);
    }


}
