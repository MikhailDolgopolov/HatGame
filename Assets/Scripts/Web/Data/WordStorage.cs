using System;
using System.Collections.Generic;

namespace Assets.Scripts.Web.Data {
    [Serializable]
    public class WordStorage {
        public int Id { get; set; }
        public List<WebWord> Words { get; set; }
        public string Keyword { get; set; }
        public User Author { get; set; }
        public DateTime CreatedOn;

        #region List Stuff
        public IEnumerator<WebWord> GetEnumerator() {
            return Words.GetEnumerator();
        }
        
        public void Add(WebWord item) {
            Words.Add(item);
        }


        public bool Contains(string item) {
            return Words.Exists(word => word.Text == item);
        }
        #endregion

        public WordStorage(string keyword, User author):this() {
            Keyword = keyword;
            Author = author;
            CreatedOn = DateTime.Today;
        }

        public WordStorage() {
            Words = new List<WebWord>();
        }

        public WebWord this[int index]
        {
            get => Words[index];
            set => Words[index] = value;
        }

        public override string ToString() {
            return $"{Keyword}{Environment.NewLine}by {Author}";
        }
    }
}
