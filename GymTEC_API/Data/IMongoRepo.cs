using System.Collections.Generic;
using GymTEC_API.Models;

namespace GymTEC_API.Data
{
    // Interface for the Mongo Repo that controls all the operations for the Employee entities in the Mongo Database
    public interface IMongoRepo{

        IEnumerable<Client> GetAllClients();
        Client GetClientByIdCard(int idCard);
        void CreateClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(Client client);

        LoginProfile CheckCredentials(LoginProfile loginProfile);
    
    }

}