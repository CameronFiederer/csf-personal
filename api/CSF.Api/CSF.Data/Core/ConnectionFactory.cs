using Npgsql;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System;

namespace CSF.Data
{
    public class ConnectionFactory
    {
        private string connectionString;
        private string dbType;

        public ConnectionFactory(IConfiguration config)
        {
            connectionString = config["CSF.Data.ConnectionString"];
            dbType = config["CSF.Data.DBType"];
        }

        public DbConnection Create()
        {
            switch(dbType)
            {
                case "Postgre":
                    return new NpgsqlConnection(connectionString);
                // May be a bit silly to do since I would have to install all of the different db providers if I wanted this truely generic.
            }

            throw new NotImplementedException("We ran into an unexpected database provider");
        }
    }
}