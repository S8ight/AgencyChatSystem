namespace BLL.DTO.Response
{
    public class MessageResponse
    {
        public int MessageID { get; set; }
        public string SenderID { get; set; }
        public string MessageBody { get; set; }
        public DateTime Created { get; set; }
    }
}
