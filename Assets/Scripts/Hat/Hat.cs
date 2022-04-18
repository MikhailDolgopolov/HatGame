using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using Assets.Scripts.Hat;
using Debug = UnityEngine.Debug;

public class Hat : MonoBehaviour {
    public List<Word> WordsList;
    void Awake() {
        DontDestroyOnLoad(gameObject);
        WordsList = new List<Word>();
    }

    void Start() {
        WordsList.Add(new Word("Балка", "HatCoder"));
    }
    

    
}
