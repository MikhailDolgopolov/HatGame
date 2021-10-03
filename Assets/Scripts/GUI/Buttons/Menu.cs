using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void PlayGame()
    {
        if (Hat.Length <= Hat.wordsThreshold)
        {
            ToastMessages.ShowMessage("В шляпе недостаточно слов.");
            return;
        }
        SceneManager.LoadScene("GameSetup");
       
    }

    public void SwitchModes() {
        Hat.useOnlineHat = !Hat.useOnlineHat;
        Hat.SetupHat();
    }
}
