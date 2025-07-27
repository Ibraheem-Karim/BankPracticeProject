namespace BankTestProjectBackend.DTOs
{
    public class RegisterDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }  // Added phone property
        public string Password { get; set; }
    }

}
