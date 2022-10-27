namespace DAL.Models
{
    public class Message
    {
        public string MessageID { get; set; }
        
        public string ChatID { get; set; }
        
        public string SenderID { get; set; }
        
        public string RecieverID { get; set; }
        
        public string MessageBody { get; set; }
        
        public DateTime Created { get; set; }
        
        public bool Checked { get; set; }
        
        public Chat Chat { get; set; }
    }
}
