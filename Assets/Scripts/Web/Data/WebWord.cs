using System;

namespace Assets.Scripts.Web.Data {
    [Serializable]
    public class WebWord{
        public int Id { get; set; }
        public string Text { get; set; }
        public User Author { get; set; }
        
        public WebWord(string t) {
            Text = t;
        }
        public WebWord(){}

        private WebWord(string t, User a) {
            Text = t;
            Author = a;
        }

        public override string ToString() {
            return $"{Text}  --  by {Author}";
        }
    }
}
