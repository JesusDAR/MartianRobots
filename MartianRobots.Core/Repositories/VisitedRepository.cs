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
    public class VisitedRepository : IVisitedRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public VisitedRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public int Add(Visited entity)
        {
            string sql = "INSERT INTO Visited (X, Y) VALUES (@X, @Y)";
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                int id = connection.Execute(sql, entity);
                return id;
            }
        }

        public void Delete()
        {
            string sql = "DELETE FROM Visited";
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Execute(sql);
            }
        }
        public IEnumerable<Visited> GetAll()
        {
            string sql = "SELECT * FROM Visited";
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                IEnumerable<Visited> visited = connection.Query<Visited>(sql);
                return visited;
            }
        }
        public Visited Get()
        {
            throw new NotImplementedException();
        }

        public int Update(Visited entity)
        {
            throw new NotImplementedException();
        }
    }
}
