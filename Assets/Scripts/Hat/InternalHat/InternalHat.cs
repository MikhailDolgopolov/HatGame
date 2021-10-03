using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InternalHat : IHat {
    public static InternalHat instance;
    public List<OldWord> Words;
    public List<int> freeIndecies;
    private int taken;
    private OldWord lastWord;
    public int GetLength(){
        if(Words!=null)
            return Words.Count-taken;
        return 0;
    }

    public InternalHat() {
        Start();
    }
    public void Start() {
        instance = this;
        Words = new List<OldWord>();
        freeIndecies=new List<int>();
        FillFreeIndecies();
        FillHat(SaveSystem.Load());
    }

    void FillFreeIndecies() {
        for (int i = 0; i < Words.Count; i++) {
            freeIndecies.Add(i);
        }
    }
    void DeleteUsed() {
        for (int i = Words.Count-1; i >=0; i--) {
            if (Words[i].needsDeleting()) {
                Words.RemoveAt(i);
            }
        }

        for (int i = 0; i < Words.Count; i++) Words[i].indexInHat = i;
        taken = 0;
        freeIndecies.Clear();
        FillFreeIndecies();
    }
    public void PrepareForRound() {
        DeleteUsed();
        Save();
    }
    public void RoundEnded() {
        
    }
    public void RemoveLastWord(bool firstPress) {
        if(!firstPress)
            taken += 1;
        freeIndecies.Remove(lastWord.indexInHat);
        lastWord.Delete();
    }

    public void PutWordBack() {
        if (!freeIndecies.Contains(lastWord.indexInHat)) freeIndecies.Add(lastWord.indexInHat);
        if (lastWord.needsDeleting()) {
            taken -= 1;
        }
        lastWord.Leave();
    }

    public static void Save() {
        if(instance!=null) SaveSystem.Save(instance);
    }
    public void WordButtonPressed() {
        lastWord.Delete();
    }

    public void GameEnded() {
        DeleteUsed();
        Save();
    }

    public bool AddWordToHat(string word)
    {
        word = word.ToLower();
        OldWord modword = new OldWord(word);
        if (Words.Contains(modword)) return false;
        modword.indexInHat = Words.Count;
        Words.Add(modword);
        Save();
        return true;
    }
    
    public IWord GetWord()
    {
        int index = Random.Range(0, freeIndecies.Count - 1);
        OldWord picked =Words[freeIndecies[index]];
        freeIndecies.RemoveAt(index);
        picked.Delete();
        lastWord = picked;
        taken += 1;
        return picked;
    }
    public void FillHat(HatData data)
    { 
        foreach (string word in data.words)
        {
            AddWordToHat(word);
        }
    }
    
}
