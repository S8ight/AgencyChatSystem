namespace BLL.DTO.Request;

public class UserRequest
{
    public string UserId { get; set; }
        
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public byte[] Photo { get; set; }
}