using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public static class WordLoader{
    private static WordRow last;
    private static bool taken;
    public static int wordsLeft;
    public static WordRow lastWord
    {
        get
        {
            taken = true;
            return last;
        }
        set
        {
            taken = false;
            last = value;
        }
    }

    private static int toLoad = 6;
    public delegate void loadDelegate();
    public static event loadDelegate WordIsReady, LoadingIsDone;
    public static IEnumerator Load() {
        for (int i = 0; i < toLoad-wordsLeft; i++) {
            lastWord=OnlineHat.instance.GetSingleWord(true);
            WordIsReady();
            yield return new WaitUntil(()=>taken);
        }
    }

    public static void LoadAll() {
        var loadingEnum = Load();
        while(loadingEnum.MoveNext()){ }
        LoadingIsDone?.Invoke();
    }
}
