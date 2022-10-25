namespace Wheelish.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserCity { get; set; }
        public string UserState { get; set; }
        public int UserZip { get; set; }
        public int UserPhone { get; set; }
        public string UserEmail { get; set; }
        private string FirebaseUserId { get; set; }

    }
}
