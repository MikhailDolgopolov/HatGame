using System.Collections;
using System.Collections.Generic;
using System.Text;
using Assets.Scripts.Web;
using Assets.Scripts.Web.Data;
using UnityEngine;
using UnityEngine.Networking;

public class WebHatFunctions : MonoBehaviour {
    public static WebHatFunctions instance;
    public static string AddRoomUrl =  "https://localhost:5001/Hat/addroom";
    public static string AddWordsUrl = "https://localhost:5001/Hat/addwords";

    void Start() {
        instance = this;
    }
    public static void AddRoom(string body) {
        instance.StartCoroutine(SendPostRequest(body, AddRoomUrl));
    }
    
    public static void AddWords(string body) {
        instance.StartCoroutine(SendPostRequest(body, AddWordsUrl));
    }

    public static void GetWords() {
        instance.StartCoroutine(SendGetRequest("https://localhost:5001/Hat"));
    }
    
    public static IEnumerator SendPostRequest(string body, string path) {
        Debug.Log(body);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(body);
        UnityWebRequest uwr =
            new UnityWebRequest(path, "POST", new DownloadHandlerBuffer(), new UploadHandlerRaw(bodyRaw));
        uwr.certificateHandler = new CertificateConman();
        uwr.SetRequestHeader("Content-Type", "application/json");
        uwr.SetRequestHeader("accept", "text/plain");
        yield return uwr.SendWebRequest();
        
        if (uwr.result == UnityWebRequest.Result.Success) {
            Debug.Log("Success");
            Debug.Log("result:   "+uwr.downloadHandler.text);
        }
        else {
            Debug.Log(uwr.error);
        }

        uwr.Dispose();
    }
    public static IEnumerator SendGetRequest(string path) {
        UnityWebRequest uwr = new UnityWebRequest(path, "GET", new DownloadHandlerBuffer(), null );
        uwr.certificateHandler = new CertificateConman();
        uwr.SetRequestHeader("Content-Type", "application/json");
        uwr.SetRequestHeader("accept", "text/plain");
        yield return uwr.SendWebRequest();
        Debug.Log($"url: {uwr.url}");
        if (uwr.result == UnityWebRequest.Result.Success) {
            Debug.Log("result:   "+uwr.downloadHandler.text);
            WebData.instance.mainStorage = JsonUtility.FromJson<WordStorage>(uwr.downloadHandler.text);
        }
        else {
            Debug.Log(uwr.error);
        }

        uwr.Dispose();
    }
}
