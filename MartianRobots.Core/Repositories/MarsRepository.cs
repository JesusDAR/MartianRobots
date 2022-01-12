using Dapper;
using MartianRobots.Core.Entities;
using MartianRobots.Core.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.Core.Repositories
{
    public class MarsRepository : IMarsRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public MarsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public int Add(Mars entity)
        {
            string sql = "INSERT INTO Mars (X, Y) VALUES (@X, @Y)";
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                int id = connection.Execute(sql, entity);
                return id;
            }
        }
        public Mars Get()
        {
            string sql = "SELECT * FROM  Mars LIMIT 1";
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                Mars mars = connection.QueryFirst<Mars>(sql);
                return mars;
            }
        }

        public void Delete()
        {
            string sql = "DELETE * FROM Mars";
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Execute(sql);
            }
        }
        public int Update(Mars entity)
        {
            string sql = "UPDATE Mars SET X = @X, Y = @Y";
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                int id = connection.Execute(sql, entity);
                return id;
            }
        }
    }
}
