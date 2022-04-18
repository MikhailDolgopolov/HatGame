using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToMenuButton : MonoBehaviour
{
    public void Quit()
    {
        //Destroy();
        throw new NotImplementedException("Destroy gameSettings");
        SceneManager.LoadScene("MainMenu");
    }
    
}
