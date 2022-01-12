﻿using Dapper;
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
            _connectionString = _configuration.GetConnectionString("DefaultConnnection");
        }
        public int Add(Information entity)
        {
            string sql = "INSERT INTO Mars (X, Y) VALUES (@X, @Y)";
            using (IDbConnection connection = new SQLiteConnection(_connectionString))
            {
                int id = connection.Execute(sql, entity);
                return id;
            }
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Information Get()
        {
            throw new NotImplementedException();
        }

        public int Update(Information entity)
        {
            throw new NotImplementedException();
        }
    }
}