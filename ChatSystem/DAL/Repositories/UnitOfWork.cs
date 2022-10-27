using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbTransaction DbTransaction;

        public IChatRepository ChatRepository { get; set; }

        public IMessageRepository MessageRepository { get; set; }

        public IUserRepository UserRepository { get; set; }

        public UnitOfWork(
            IDbTransaction dbTransaction,
            IChatRepository chatRepository,
            IMessageRepository messageRepository,
            IUserRepository userRepository)
        {
            DbTransaction = dbTransaction;
            ChatRepository = chatRepository;
            MessageRepository = messageRepository;
            UserRepository = userRepository;
        }

        public void Commit()
        {
            try
            {
                DbTransaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                DbTransaction.Rollback();
            }
        }

        public void Dispose()
        {
            DbTransaction.Connection?.Close();
            DbTransaction.Connection?.Dispose();
            DbTransaction.Dispose();
        }
    }
}
