using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldWord : IWord {
    public string content { get; private set; }
    private bool delete;
    public int indexInHat;
    public static implicit operator string(OldWord w) => w.content;
    public static implicit operator OldWord(string content) => new OldWord(content);
    public static bool operator ==(OldWord w1, OldWord w2) => w1.content == w2.content;
    public static bool operator !=(OldWord w1, OldWord w2) => w1.content != w2.content;
    public override bool Equals(object obj) {
        return !(obj is null) && content == ((OldWord) obj).content;
    }

    public override int GetHashCode() {
        return content.GetHashCode();
    }

    public void Delete() {
        delete = true;
    }

    public bool needsDeleting() {
        return delete;
    }

    public void Leave() {
        delete = false;
    }

    public string GetString() {
        return content;
    }
    public OldWord(string word) {
        content = word;
    }
}
