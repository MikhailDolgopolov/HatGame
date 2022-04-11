using System;

namespace Assets.Scripts.Web.Data {
    [Serializable]
    public class Word{
        public int Id { get; set; }
        public string Text { get; set; }
        public User Author { get; set; }
        
        public Word(string t) {
            Text = t;
        }
        public Word(){}

        private Word(string t, User a) {
            Text = t;
            Author = a;
        }

        public override string ToString() {
            return $"{Text}  --  by {Author}";
        }
    }
}
