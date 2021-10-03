using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRcode : MonoBehaviour {
    public GameObject Input, QRCode;
    void Start() {
        Hat.HatChanged += Switch;
        Switch();
    }

    void Switch() {
        if(Input==null) Input=GameObject.Find("Input");
        if(QRCode==null) QRCode = GameObject.Find("QR");
        if (Hat.useOnlineHat) {
            QRCode.SetActive(true);
            Input.SetActive(false);
            return;
        }
        Input.SetActive(true);
        QRCode.SetActive(false);
    }
}
