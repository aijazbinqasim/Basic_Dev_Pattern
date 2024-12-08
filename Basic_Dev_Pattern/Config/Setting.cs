namespace Basic_Dev_Pattern.Config
{
    // Root class
    public class Setting
    {
        public User? User { get; set; }
        public Password? Password { get; set; }
        public Validation? Validation { get; set; }
        public Programming? Programming { get; set; }
    }

    public class User
    {
        public string? UserName { get; set; }
    }

    public class Password
    {
        public string? UserPwd { get; set; }
    }

    public class Validation
    {
        public bool? RememberMe { get; set; }
    }

    public class Programming
    {
        public IList<string>? Languages { get; set; }
    }
}
