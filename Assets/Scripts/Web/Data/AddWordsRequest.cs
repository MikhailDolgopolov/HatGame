namespace Assets.Scripts.Web.Data {
    public class AddWordsRequest {
        public string roomKeyword;
        public string[] words;
        public string authorNickname;
        
        public AddWordsRequest(string keyword, string[] body) {
            roomKeyword = keyword;
            words = body;
        }

        public AddWordsRequest(string keyword, string[] body, string author):this(keyword,body){
            authorNickname = author;
        }
        public AddWordsRequest(){}
    }
}