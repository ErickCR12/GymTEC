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

        
        //-------------------PAYROLLS ENTITIES MANAGMENT--------------------//

        //Calls the stored SQL Function that returns all the existing Payrolls entities in the database.
        IEnumerable<Payroll> GetAllPayrolls();
        //Calls the stored SQL Function that returns the existing Payroll entity in the database with the matching id.
        Payroll GetPayrollById(int id);
        //Calls the stored SQL Procedure that inserts, updates or deletes a Payroll Entity in the database..
        void CreateUpdateDeletePayroll(Payroll payroll, string statementType);


        //---------------POSITION ENTITIES MANAGMENT------------------//

        //Calls the stored SQL Function that returns all the existing Positions entities in the database.
        IEnumerable<GymService> GetAllPositions();
        //Calls the stored SQL Function that returns the existing Positions entity in the database with the matching id.
        GymService GetPositionById(int id);
        //Calls the stored SQL Procedure that inserts, updates or deletes a Position Entity in the database..
        void CreateUpdateDeletePosition(GymService position, string statementType);


        //---------------CLASS ENTITIES MANAGMENT------------------//

        //Calls the stored SQL Function that returns all the existing Classes entities in the database.
        IEnumerable<GymClass> GetAllClasses();
        //Calls the stored SQL Function that returns the existing Class entity in the database with the matching id.
        GymClass GetClassById(int id);
        //Calls the stored SQL Procedure that inserts, updates or deletes a Class Entity in the database..
        void CreateUpdateDeleteClass(GymClass gymClass, string statementType);





    
    }

}