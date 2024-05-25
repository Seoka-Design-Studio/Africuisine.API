namespace Africuisine.Application.Data.Command.Users
{
    public class UserCommand
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public Guid LCGroup { get; set; }
    }
}
