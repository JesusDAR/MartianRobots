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
    public class InformationRepository : IInformationRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public InformationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public int Add(Information entity)
        {
            string sql = "INSERT INTO Information (RobotsLost, RobotsSucceeded, SurfaceExplored, SurfaceUnexplored) VALUES (@RobotsLost, @RobotsSucceeded, @SurfaceExplored, @SurfaceUnexplored)";
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                int id = connection.Execute(sql, entity);
                return id;
            }
        }
        public int Update(Information entity)
        {
            string sql = "UPDATE Information SET RobotsLost = @RobotsLost, RobotsSucceeded = @RobotsSucceeded, SurfaceExplored = @SurfaceExplored, SurfaceUnexplored = @SurfaceUnexplored";
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                int id = connection.Execute(sql, entity);
                return id;
            }
        }
        public void Delete()
        {
            string sql = "DELETE FROM Information";
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Execute(sql);
            }
        }
        public Information Get()
        {
            string sql = "SELECT * FROM  Information";
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                Information information = connection.QueryFirst<Information>(sql);
                return information;
            }
        }
    }
}
