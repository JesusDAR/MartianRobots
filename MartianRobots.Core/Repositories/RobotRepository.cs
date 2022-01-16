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
    public class RobotRepository : IRobotRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public RobotRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public int Add(Robot entity)
        {
            string sql = "INSERT INTO Robots (X_Initial, Y_Initial, Or_Initial, X_End, Y_End, Or_End, Success) VALUES (@X_Initial, @Y_Initial, @Or_Initial, @X_End, @Y_End, @Or_End, @Success)";
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                int id = connection.Execute(sql, entity);
                return id;
            }
        }
        public void Delete()
        {
            string sql = "DELETE FROM Robots";
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Execute(sql);
            }
        }
        public IEnumerable<Robot> GetAll()
        {
            string sql = "SELECT * FROM Robots";
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                IEnumerable<Robot> robots = connection.Query<Robot>(sql);
                return robots;
            }
        }
        public Robot Get()
        {
            throw new NotImplementedException();
        }
        public int Update(Robot entity)
        {
            throw new NotImplementedException();
        }
    }
}
