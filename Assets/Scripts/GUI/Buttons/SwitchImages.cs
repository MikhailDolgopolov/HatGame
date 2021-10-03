using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchImages : MonoBehaviour {
    public Image image;
    public Sprite Web, Phone;

    void Start() {
        PhoneImage();
    }
    
    public void WebImage() {
        image.sprite = Web;
    }

    public void PhoneImage() {
        image.sprite = Phone;
    }
}
