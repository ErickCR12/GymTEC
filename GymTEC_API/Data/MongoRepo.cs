
using System;
using System.Collections.Generic;
using System.Data;
using GymTEC_API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace GymTEC_API.Data
{
    public class MongoRepo : IMongoRepo
    {

        IMongoCollection<Client> mongoClientCollection;
        
        public MongoRepo(IConfiguration config) 
        {
            var uri = config.GetValue<string>("MongoUri");
            var mongoConnection = new MongoClient(uri);
            var mongoDB = mongoConnection.GetDatabase("GymTEC");
            mongoClientCollection = mongoDB.GetCollection<Client>("EMPLEADOS");
        }

        public IEnumerable<Client> GetAllClients()
        {

            return mongoClientCollection.Find(_ => true).ToList();

        }

        public Client GetClientByIdCard(int idCard)
        {
            return mongoClientCollection.Find(s => s.idCard == idCard).FirstOrDefault();
        }


        public void CreateClient(Client client)
        {
            mongoClientCollection.InsertOne(client);
        }
        
        public void UpdateClient(Client client)
        {
            mongoClientCollection.ReplaceOne(s => s.idCard == client.idCard, client);
        }

        public void DeleteClient(Client client)
        {
            mongoClientCollection.DeleteOne(s => s.idCard == client.idCard);
        }

        public LoginProfile CheckCredentials(LoginProfile loginProfile)
        {
            Client client = GetClientByIdCard(loginProfile.Username);
            loginProfile.UserType = (client != null) ? "Client":"Invalid";
            return loginProfile;
        }
    }
}