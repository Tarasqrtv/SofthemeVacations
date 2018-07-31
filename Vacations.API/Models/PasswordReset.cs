namespace Vacations.API.Models
{
    public class PasswordReset
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
    }
}
