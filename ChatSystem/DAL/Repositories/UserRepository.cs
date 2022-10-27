
using System.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration configuration;
        
        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        public async Task<string> AddAsync(User t)
        {
            var sql = "Insert into User (UserId,FirstName,LastName,Photo) VALUES (@UserId,@FirstName,@LastName,@Photo) ";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandText = sql;
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@UserId", t.UserId);
                    cmd.Parameters.AddWithValue("@FirstName", t.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", t.LastName);
                    cmd.Parameters.AddWithValue("@Photo", t.Photo);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
            return t.UserId;
        }
        
        public async Task<Task> DeleteAsync(string id)
        {
            {
                var sql = "DELETE FROM User WHERE UserId = @UserId";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@UserId", id);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                return Task.CompletedTask;
            }
        }
        
        public async Task<User> GetAsync(string id)
        {
            User user = new User();
            var sql = "SELECT * FROM User WHERE UserId = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql,connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user.UserId = Convert.ToString(reader["Id"]);
                            user.FirstName = Convert.ToString(reader["FirstName"]);
                            user.LastName = Convert.ToString(reader["LastName"]);
                            //user.Photo = Convert.ToByte(reader["Photo"]);
                        }
                    }
                }
                connection.Close();
                return user;
            }
        }
        
        
        public async Task<Task> ReplaceAsync(User t)
        {
            {
                var sql = "UPDATE User SET UserId = @UserId,FirstName = @FirstName,LastName = @LastName,Photo = @Photo";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@UserId", t.UserId);
                        cmd.Parameters.AddWithValue("@Name", t.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", t.LastName);
                        cmd.Parameters.AddWithValue("@Photo", t.Photo);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                return Task.CompletedTask;
            }
        }
    }
}
