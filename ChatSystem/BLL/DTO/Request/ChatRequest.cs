namespace BLL.DTO.Request
{
    public class ChatRequest
    {
        public int ChatID { get; set; }
        
        public string UserID { get; set; }
        public string RecieverID { get; set; }
        public DateTime Created { get; set; }
    }
}
