using Microsoft.AspNetCore.Identity;
using static System.Net.Mime.MediaTypeNames;

namespace DAL.Models
{
    public class User
    {
        public string UserId { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] Photo { get; set; }
        
        public List<Chat> Chat { get; set; }
    }
}
