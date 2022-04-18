using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Assets.Scripts.Web;
using Assets.Scripts.Web.Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class WebCanvasUi : MonoBehaviour {
    public TMP_InputField words, author, keyword;
    

    // Start is called before the first frame update
    void Start() {
        
    }

    public void AddRoom() {
        //WebHatFunctions.SetRoom("Unity");
        WebHatFunctions.AddRoom(JsonUtility.ToJson(GenerateAddRoomRequest(), true), 
            (request, s) =>
            {
                WebData.instance.mainStorage = JsonUtility.FromJson<WordStorage>(s);
            });
    }

    public void AddWords() {
        WebHatFunctions.AddWords(JsonUtility.ToJson(GenerateAddWordsRequest(), true),
            (request, s) =>
            {
                Debug.Log(request.error);
                Debug.Log(s);
            });
    }

    public AddRoomRequest GenerateAddRoomRequest(string key = null, string name = null) {
        return new AddRoomRequest(key ?? keyword.text, name ?? author.text);
    }

    public AddWordsRequest GenerateAddWordsRequest() {
        return new AddWordsRequest(keyword.text, WordRefinery.Split(words.text), author.text);
    }
}
