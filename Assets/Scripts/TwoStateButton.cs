using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TwoStateButton : Selectable, IEventSystemHandler, IPointerClickHandler, ISubmitHandler {
    public UnityEvent onClick, onPress, onRelease;
    public bool isPressed;
    public int pressCounter { get; private set; }
    public int releaseCounter { get; private set; }
    public void OnPointerClick(PointerEventData eventData) {
        onClick.Invoke();
        if (isPressed) {
            OnRelease();
            isPressed = false;
            return;
        }
        isPressed = true;
        OnPress();
    }
    
    private void OnRelease() {
        releaseCounter += 1;
        onRelease.Invoke();
    }

    private void OnPress() {
        Select();
        pressCounter += 1;
        onPress.Invoke();
    }

    public void OnSubmit(BaseEventData eventData) {
    }
}
