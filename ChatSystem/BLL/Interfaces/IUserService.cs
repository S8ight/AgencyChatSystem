using BLL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO.Request;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        public Task<UserResponse> GetAsync(string id);
        public Task<string> AddAsync(UserRequest request);
        public Task DeleteAsync(string id);
        public Task ReplaceAsync(UserRequest request);

    }
}
