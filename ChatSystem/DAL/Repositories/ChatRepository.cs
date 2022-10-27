using DAL.Interfaces;
using DAL.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repositories
{
    public class ChatRepository : GenericRepository<Chat>, IChatRepository
    {
        public ChatRepository(SqlConnection sqlConnection, IDbTransaction dbTransaction) : base(sqlConnection, dbTransaction)
        {
        }
        // private readonly IConfiguration configuration;
        //
        // public ChatRepository(IConfiguration configuration)
        // {
        //     this.configuration = configuration;
        // }

        // public async Task<int> AddAsync(Chat t)
        // {
        //     var sql = "SET IDENTITY_INSERT Chat ON Insert into Chat (ChatID,SellerID,UserID) VALUES (@ChatID,@SellerID,@UserID) SET IDENTITY_INSERT Chat OFF ";
        //     using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //     {
        //         connection.Open();
        //         var result = await connection.ExecuteAsync(sql, new
        //         {
        //             t.ChatID,
        //             t.SellerID,
        //             t.UserID
        //         });
        //         return result;
        //     }
        // }
        //
        // public async Task DeleteAsync(int id)
        // {
        //     using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //     {
        //         using (SqlCommand cmd = new SqlCommand("DeleteChat", connection))
        //         {
        //             cmd.CommandType = CommandType.StoredProcedure;
        //             cmd.Parameters.Add("@ChatId", SqlDbType.Int).Value = id;
        //             connection.Open();
        //             cmd.ExecuteNonQuery();
        //         }
        //     }
        // }
        //
        // public async Task<IEnumerable<Chat>> GetAllAsync()
        // {
        //     var sql = "SELECT * FROM Chat";
        //     using (var connection = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection")))
        //     {
        //         connection.Open();
        //         var result = await connection.QueryAsync<Chat>(sql);
        //         return result.ToList();
        //     }
        // }
        //
        // public async Task<Chat> GetAsync(int id)
        // {
        //     var sql = "SELECT * FROM Chat WHERE ChatID = @ID";
        //     using (var connection = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection")))
        //     {
        //         connection.Open();
        //         var result = await connection.QuerySingleOrDefaultAsync<Chat>(sql, new { ID = id });
        //         return result;
        //     }
        // }
        //
        // public async Task ReplaceAsync(Chat t)
        // {
        //     var sql = "UPDATE Chat SET SellerID = @SellerID, UserID = @UserID WHERE ChatID = @ChatID";
        //     using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //     {
        //         connection.Open();
        //         var result = await connection.ExecuteAsync(sql, new
        //         {
        //             t.ChatID,
        //             t.SellerID,
        //             t.UserID
        //         });
        //     }
        // }
    }
}
