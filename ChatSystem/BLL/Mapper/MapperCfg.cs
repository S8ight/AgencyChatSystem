using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using AutoMapper;
using DAL.Models;
using BLL.DTO.Request;
using BLL.DTO.Response;

namespace DAL.Mapper
{
    public class MapperCfg : Profile
    {
        public MapperCfg()
        {
            CreateMap<ChatRequest, Chat>();
            CreateMap<Chat, ChatResponse>();
            CreateMap<MessageRequest, Message>();
            CreateMap<Message, MessageResponse>();
            CreateMap<User, UserResponse>();
            CreateMap<UserRequest, User>();
        }
    }
}
