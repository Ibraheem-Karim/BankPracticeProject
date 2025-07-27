namespace BankTestProjectBackend.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }  // Optional: Include phone in response
    }
}
