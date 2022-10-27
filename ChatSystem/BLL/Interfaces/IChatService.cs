using BLL.DTO.Request;
using BLL.DTO.Response;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IChatService
    {
        public Task<IEnumerable<ChatResponse>> GetAllAsync();
        public Task<ChatResponse> GetByIdAsync(int id);
        public Task UpdateAsync(ChatRequest request);
        public Task<int> AddAsync(ChatRequest request);
        public Task DeleteAsync(int id);
    }
}
