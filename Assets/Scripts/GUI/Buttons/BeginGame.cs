using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour
{
    public void Begin()
    {
        if (GameSettings.numberOfPlayers < 2)
        {
            ToastMessages.ShowMessage("Недостаточно игроков. Добавьте минимум двоих.");
            return;
        }
        if(GameSettings.secondsPerRound == 0)
        {
            ToastMessages.ShowMessage("Время на один раунд не указано. Требуется число, отличное от нуля.");
            return;
        }
        GameSettings.GeneratePairs();
        SceneManager.LoadScene("MainGame");
    }
    
}
