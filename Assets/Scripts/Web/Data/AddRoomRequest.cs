using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Web.Data {
    public class AddRoomRequest {
        public string keyword;
        public string author;

        public AddRoomRequest(string k, string a) {
            keyword = k;
            author = a;
        }
        public AddRoomRequest(){}

        public Dictionary<string, string> GeneratePairs() {
            return new Dictionary<string, string>()
            {
                {"keyword",keyword},
                {"author", author}
            };
        }
    }
}
