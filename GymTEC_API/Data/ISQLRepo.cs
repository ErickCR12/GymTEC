using System.Collections.Generic;
using GymTEC_API.Models;

namespace GymTEC_API.Data
{
    // Interface for the SQL Repo that controls all the operations for the entities in the SQL Server Database
    public interface ISQLRepo{

        //----------------------GYM ENTITIES MANAGMENT-----------------------//

        //Calls the stored SQL Function that returns all the existing Gym entities in the database.
        IEnumerable<Gym> GetAllGyms();
        //Calls the stored SQL Function that returns the existing Gym entity in the database with the matching id.
        Gym GetGymById(int id);
        //Calls the stored SQL Procedure that inserts, updates or deletes a Gym Entity in the database..
        void CreateUpdateDeleteGym(Gym gym, string statementType);

        
        //---------------SPA TREATMENTS ENTITIES MANAGMENT------------------//

        //Calls the stored SQL Function that returns all the existing Spa Treatments entities in the database.
        IEnumerable<GymService> GetAllSpaTreatments();
        //Calls the stored SQL Function that returns the existing Spa Treatment entity in the database with the matching id.
        GymService GetSpaTreatmentById(int id);
        //Calls the stored SQL Procedure that inserts, updates or deletes a Spa Treatment Entity in the database..
        void CreateUpdateDeleteSpaTreatment(GymService spaTreatment, string statementType);





    
    }

}