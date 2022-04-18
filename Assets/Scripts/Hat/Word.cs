using System;

namespace Assets.Scripts.Hat {
    [Serializable]
    public class Word {
        public string Text;
        public string Author;
        public bool used { get; private set; }

        public Word(string content, string name=null) {
            Text = content;
            Author = name;
            used = false;
        }
    }
}