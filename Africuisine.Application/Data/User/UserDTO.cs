namespace Africuisine.Application.Data.User
{
    public class UserDTO : BaseDTO
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public bool IsVerified { get; set; }
        public string CulturalGroupName { get; set; }
    }
}
