﻿using DAL.Interfaces;
using Dapper;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace DAL.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected SqlConnection _sqlConnection;

        protected IDbTransaction _dbTransaction;

        private readonly string _tableName = typeof(T).Name;

        protected GenericRepository(SqlConnection sqlConnection, IDbTransaction dbTransaction)
        {
            _sqlConnection = sqlConnection;
            _dbTransaction = dbTransaction;
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _sqlConnection.QueryAsync<T>($"SELECT * FROM {_tableName}", 
                transaction: _dbTransaction);
        }

        public async Task<T> GetAsync(int id)
        {
            var properties = GenerateListOfProperties(GetProperties);
            var result = await _sqlConnection.QuerySingleOrDefaultAsync<T>($"SELECT * FROM {_tableName} WHERE {properties.First()}=@Id", 
                param: new { Id = id }, 
                transaction: _dbTransaction);
            if (result == null)
                throw new KeyNotFoundException($"{_tableName} with id [{id}] could not be found.");
            return result;
        }

        public async Task DeleteAsync(int id)
        {
            var properties = GenerateListOfProperties(GetProperties);
            await _sqlConnection.ExecuteAsync($"DELETE FROM {_tableName} WHERE {properties.First()}=@Id", 
                param: new { Id = id }, 
                transaction: _dbTransaction);
        }


        public async Task<int> AddAsync(T model)
        {
            var insertQuery = GenerateInsertQuery();
            var newId = await _sqlConnection.ExecuteScalarAsync<int>(insertQuery,
                param: model,
                transaction: _dbTransaction);
            return newId;
        }

        public async Task<int> AddRangeAsync(IEnumerable<T> list)
        {
            var inserted = 0;
            var query = GenerateInsertQuery();
            inserted += await _sqlConnection.ExecuteAsync(query, 
                param: list);
            return inserted;
        }


        public async Task ReplaceAsync(T model)
        {
            var updateQuery = GenerateUpdateQuery();
            await _sqlConnection.ExecuteAsync(updateQuery, 
                param: model, 
                transaction: _dbTransaction);
        }
        
        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();
        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop.Name).ToList();
        }
        
        private string GenerateUpdateQuery()
        {
            var updateQuery = new StringBuilder($"UPDATE {_tableName} SET ");
            var properties = GenerateListOfProperties(GetProperties);
            properties.ForEach(property =>
            {
                if (!property.Equals($"{properties.First()}"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });
            updateQuery.Remove(updateQuery.Length - 1, 1);
            updateQuery.Append($" WHERE {properties.First()}=@{properties.First()}");
            return updateQuery.ToString();
        }
        
        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($" SET IDENTITY_INSERT {_tableName} ON; INSERT INTO {_tableName} ");
            insertQuery.Append("(");
            var properties = GenerateListOfProperties(GetProperties);
            
            properties.ForEach(prop => { insertQuery.Append($"[{prop}],"); });
            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });
            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");
            insertQuery.Append($"; SELECT SCOPE_IDENTITY();");
            return insertQuery.ToString();
        }
    }
}
