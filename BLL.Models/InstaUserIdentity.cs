namespace BLL.Models
{
    public class InstaUserIdentity
    {
        public string Handle { get; }

        public string Id { get; }

        public InstaUserIdentity(string handle, string id)
        {
            Handle = handle;
            Id = id;
        }
    }
}