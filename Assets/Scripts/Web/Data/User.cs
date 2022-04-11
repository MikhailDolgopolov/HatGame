using System;

namespace Assets.Scripts.Web.Data {
    [Serializable]
    public class User {
        public string Nickname { get; set; }
        public int numberOfContributions { get; set; }
        public int Id
        { get; set; }
        
        public User(string name) {
            Nickname = name;
            numberOfContributions = 0;
        }

        public User() {
        }

        public override string ToString() {
            return $"User {Nickname} has {numberOfContributions} contributions.";
        }
    }
}