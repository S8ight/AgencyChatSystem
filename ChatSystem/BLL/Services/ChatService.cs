using AutoMapper;
using BLL.DTO.Request;
using BLL.DTO.Response;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ChatService : IChatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChatService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ChatResponse>> GetAllAsync()
        {
            var chats = await _unitOfWork.ChatRepository.GetAllAsync();
            return chats?.Select(_mapper.Map<Chat, ChatResponse>);
        }

        public async Task<ChatResponse> GetByIdAsync(int id)
        {
            var chat = await _unitOfWork.ChatRepository.GetAsync(id);
            return _mapper.Map<Chat, ChatResponse>(chat);
        }

        public async Task UpdateAsync(ChatRequest request)
        {
            var chat = _mapper.Map<ChatRequest, Chat>(request);
            await _unitOfWork.ChatRepository.ReplaceAsync(chat);
            _unitOfWork.Commit();
        }

        public async Task<int> AddAsync(ChatRequest request)
        {
            var chat = _mapper.Map<ChatRequest, Chat>(request);
            var newChat = await _unitOfWork.ChatRepository.AddAsync(chat);
            _unitOfWork.Commit();
            return newChat;
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.ChatRepository.DeleteAsync(id);
            _unitOfWork.Commit();
        }
    }

}
