namespace BLL.DTO.Request
{
    public class MessageRequest
    {
        public int MessageID { get; set; }
        public int ChatID { get; set; }
        public string SenderID { get; set; }
        public string RecieverID { get; set; }
        public string MessageBody { get; set; }
        public DateTime Created { get; set; }
    }
}
