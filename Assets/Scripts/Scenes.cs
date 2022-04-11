using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    private Hat hat;
    // Start is called before the first frame update
    void Start()
    {
        hat = FindObjectOfType<Hat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            GameSettings settings = FindObjectOfType<GameSettings>();
            Destroy(settings.gameObject);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
