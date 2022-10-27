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
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MessageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MessageResponse>> GetAllAsync()
        {
            var message = await _unitOfWork.MessageRepository.GetAllAsync();
            return message?.Select(_mapper.Map<Message, MessageResponse>);
        }

        public async Task<MessageResponse> GetAsync(int id)
        {
            var message = await _unitOfWork.MessageRepository.GetAsync(id);
            return _mapper.Map<Message, MessageResponse>(message);
        }

        public async Task UpdateAsync(MessageRequest request)
        {
            var message = _mapper.Map<MessageRequest, Message>(request);
            await _unitOfWork.MessageRepository.ReplaceAsync(message);
            _unitOfWork.Commit();
        }

        public async Task<int> AddAsync(MessageRequest request)
        {
            var message = _mapper.Map<MessageRequest, Message>(request);
            var newId = await _unitOfWork.MessageRepository.AddAsync(message);
            _unitOfWork.Commit();
            return newId;
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.MessageRepository.DeleteAsync(id);
            _unitOfWork.Commit();
        }
    }
}
