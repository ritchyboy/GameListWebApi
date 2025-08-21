using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameListWebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
        [PasswordPropertyText]
        public string ConfirmPassword { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
