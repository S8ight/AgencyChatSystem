namespace DAL.Models
{
    public class Chat
    {
        public string ChatID { get; set; }
        
        public string UserID { get; set; }
        public string RecieverID { get; set; }
        public DateTime Created { get; set; }
        

        public User User { get; set; }
        public List<Message> Messages { get; set; }
    }
}
