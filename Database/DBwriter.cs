using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EscapeFromTheWoods
{

    public class DBwriter
    {
        private IMongoDatabase database;

        public DBwriter(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
        }

        public void WriteWoodRecords(List<DBWoodRecord> data)
        {
            var collection = database.GetCollection<DBWoodRecord>("WoodRecords");
            collection.InsertMany(data);
        }

        public void WriteMonkeyRecords(List<DBMonkeyRecord> data)
        {
            var collection = database.GetCollection<DBMonkeyRecord>("MonkeyRecords");
            collection.InsertMany(data);
        }
    }
}
