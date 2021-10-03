using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Random = System.Random;
using System.Threading;
using Debug = UnityEngine.Debug;

public class OnlineHat : IHat {
    public List<int> freeEntries;
    public int freeLen = -1;
    private readonly ArrayList preloadedWords = new ArrayList();
    private int preloaded;
    private WordRow lastWord;
    public static OnlineHat instance;
    private Random random=new Random();
    private Thread addRemoveThread;
    public int GetLength() {
        return freeLen+preloaded;
    }
    public OnlineHat() {
        Start();
    }
    public void Start() {
        instance = this;
        FillFreeEntries();
        WordLoader.WordIsReady += PreloadWord;
        WordLoader.LoadingIsDone += PrintPreloaded;
    }
    void Preload() {
        WordLoader.wordsLeft = preloadedWords.Count;
        Thread t = new Thread(WordLoader.LoadAll);
        t.Start();
    }

    void PrintPreloaded() {
        string s = "Was preloaded: ";
        foreach (WordRow w in preloadedWords) {
            s += $"{w.GetString()}, ";
        }
    }

    void PreloadWord() {
        preloadedWords.Add(WordLoader.lastWord);
    }

    public void PrepareForRound() {
        Preload();
        addRemoveThread = null;
    }

    public void RoundEnded() {
        random=new Random();
    }

    public void RemoveLastWord(bool firstPress) {
        if(!firstPress)
            freeLen -= 1;
        freeEntries.Remove(lastWord.row);
        if (addRemoveThread!=null && addRemoveThread.IsAlive) addRemoveThread.Join();
        addRemoveThread = new Thread(lastWord.Delete);
        addRemoveThread.Start();
    }
    public void PutWordBack() {
        if(!freeEntries.Contains(lastWord.row))
            freeEntries.Add(lastWord.row);
        if(lastWord.needsDeleting())
            freeLen += 1;
        if (addRemoveThread!=null&&addRemoveThread.IsAlive) addRemoveThread.Join();
        addRemoveThread = new Thread(lastWord.Free);
        addRemoveThread.Start();
    }
    public void GameEnded() {
        Thread t = new Thread(WordsTable.EndGame);
        t.Start();
    }
    
    public void WordButtonPressed() {
        lastWord.DeleteAsync();
    }
    
    public WordRow GetSingleWord(bool preload = false) {
        int index = random.Next(0, freeEntries.Count);
        int grabAWord = freeEntries[index];
        WordRow word = WordsTable.GetWord(grabAWord);
        freeEntries.RemoveAt(index);
        freeLen -= 1;
        if (preload) {
            preloaded += 1;
        }
        else {
            lastWord = word;
        }
        word.Take();
        return word;
    }
    public IWord GetWord() {
        if (preloadedWords.Count > 0) {
            int index = random.Next(0, preloadedWords.Count);
            WordRow grabbed = (WordRow)preloadedWords[index];
            lastWord = grabbed;
            preloadedWords.Remove(grabbed);
            freeLen -= 1;
            return grabbed;
        }

        return GetSingleWord();
    }

    void FillFreeEntries() {
        string[] data = WordsTable.GetRange(WordsTable.WordsCount, "A");
        freeEntries = new List<int>();
        for (int i = 0; i < data.Length; i++) {
            freeEntries.Add(Int32.Parse(data[i]));
        }
        freeLen = freeEntries.Count;
    }
}
