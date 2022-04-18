using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour
{
    public void Begin()
    {
        if (GameSettings.instance.numberOfPlayers < 2)
        {
            ToastMessages.ShowMessage("Недостаточно игроков. Добавьте минимум двоих.");
            return;
        }
        if(GameSettings.instance.secondsPerRound == 0)
        {
            ToastMessages.ShowMessage("Время на один раунд не указано. Требуется число, отличное от нуля.");
            return;
        }
        SettingsManager.instance.GeneratePairs();
        SceneManager.LoadScene("MainGame");
    }
    
}
