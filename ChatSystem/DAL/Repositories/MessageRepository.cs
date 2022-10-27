using DAL.Interfaces;
using DAL.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(SqlConnection sqlConnection, IDbTransaction dbTransaction) : base(sqlConnection, dbTransaction)
        {
        }

        public async Task<IEnumerable<Message>> GetMessagesOfUser(string UserID)
        {
            return await _sqlConnection.QueryAsync<Message>($"SELECT * FROM Message WHERE SenderID=@UserID", 
                transaction: _dbTransaction);
        }
    }
}
