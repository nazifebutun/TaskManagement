namespace TaskManagement.Models.Authentication
{
    public class Register
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }

    }
}
