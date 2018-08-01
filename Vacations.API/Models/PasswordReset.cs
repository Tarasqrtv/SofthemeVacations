namespace Vacations.API.Models
{
    public class PasswordReset
    {
        public string EmployeeId { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
    }
}
