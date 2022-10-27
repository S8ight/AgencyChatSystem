using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IChatRepository ChatRepository { get; set; }

        IMessageRepository MessageRepository { get; set; }

        IUserRepository UserRepository { get; set; }

        void Commit();

        void Dispose();
    }
}
