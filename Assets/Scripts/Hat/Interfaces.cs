using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHat {
    public IWord GetWord();
    public void PrepareForRound();
    public void RoundEnded();
    public int GetLength();
    public void WordButtonPressed();
    public void RemoveLastWord(bool firstPress);
    public void PutWordBack();
    public void GameEnded();
}

public interface IWord {
    public string GetString();
}
