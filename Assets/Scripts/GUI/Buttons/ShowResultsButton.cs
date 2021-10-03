using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowResultsButton : MonoBehaviour
{
    public GameObject Scores;
    public GameObject quitButton;

    void Start()
    {
        Scores.SetActive(false);
        quitButton.SetActive(false);
    }
    public void ShowResults()
    {
        gameObject.SetActive(false);
        Scores.SetActive(true);
        quitButton.SetActive(true);
    }
}
