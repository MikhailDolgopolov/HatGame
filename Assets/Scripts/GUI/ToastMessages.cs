﻿using System.Collections;
using System.Collections.Generic;
using Google.Apis.Util;
using UnityEngine;

public static class ToastMessages
{
    public static void ShowMessage(string message)
    {
        #if UNITY_EDITOR
        Debug.Log(message);
        #else
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity, message, 0);
                toastObject.Call("show");
            }));
        }
        #endif
    }
}
