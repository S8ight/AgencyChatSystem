using BLL.DTO.Request;
using BLL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMessageService
    {
        public Task<IEnumerable<MessageResponse>> GetAllAsync();
        public Task<MessageResponse> GetAsync(int id);
        public Task UpdateAsync(MessageRequest request);
        public Task<int> AddAsync(MessageRequest request);
        public Task DeleteAsync(int id);
    }
}
