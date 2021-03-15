namespace BLL.Models.InstaUser
{
    public class InstaUser
    {
        public InstaUserIdentity Identity { get; }

        public string Name { get; }

        public string Bio { get; }

        public int Followers { get; }

        public InstaUser(InstaUserIdentity identity, string name, string bio, int followers)
        {
            Identity = identity;
            Name = name;
            Bio = bio;
            Followers = followers;
        }
    }
}