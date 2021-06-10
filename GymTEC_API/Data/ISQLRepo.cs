using System.Collections.Generic;
using GymTEC_API.Models;

namespace GymTEC_API.Data
{
    // Interface for the SQL Repo that controls all the operations for the entities in the SQL Server Database
    public interface ISQLRepo{

        LoginProfile CheckCredentials(LoginProfile loginProfile);

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


        //------------------SERVICES ENTITIES MANAGMENT--------------------//

        //Calls the stored SQL Function that returns all the existing Service entities in the database.
        IEnumerable<GymService> GetAllServices();
        //Calls the stored SQL Function that returns the existing Service entity in the database with the matching id.
        GymService GetServiceById(int id);
        //Calls the stored SQL Procedure that inserts, updates or deletes a Service Entity in the database..
        void CreateUpdateDeleteService(GymService service, string statementType);

        
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


        
        //-----------EQUIPMENT TYPES ENTITIES MANAGMENT------------//

        //Calls the stored SQL Function that returns all the existing Equipment Types entities in the database.
        IEnumerable<GymService> GetAllEquipmentTypes();
        //Calls the stored SQL Function that returns the existing Equipment Type entity in the database with the matching id.
        GymService GetEquipmentTypeById(int id);
        //Calls the stored SQL Procedure that inserts, updates or deletes a Equipment Type Entity in the database..
        void CreateUpdateDeleteEquipmentType(GymService equipmenType, string statementType);


        //-----------EXCERCISE MACHINES MANAGMENT------------//

        //Calls the stored SQL Function that returns all the existing Excercise Machines entities in the database.
        IEnumerable<ExcerciseMachine> GetAllMachines();
        //Calls the stored SQL Function that returns the existing Excercise Machine entity in the database with the matching id.
        ExcerciseMachine GetMachineBySerialNumber(int serialNumber);
        //Calls the stored SQL Procedure that inserts, updates or deletes a Excercise Machine Entity in the database..
        void CreateUpdateDeleteMachine(ExcerciseMachine equipmenType, string statementType);


        //-----------PRODUCTS MANAGMENT------------//

        //Calls the stored SQL Function that returns all the existing Products entities in the database.
        IEnumerable<Product> GetAllProducts();
        //Calls the stored SQL Function that returns the existing Products entity in the database with the matching id.
        Product GetProductByBarCode(int barCode);
        //Calls the stored SQL Procedure that inserts, updates or deletes a Products Entity in the database..
        void CreateUpdateDeleteProduct(Product product, string statementType);

    
        //-----------EMPLOYEES MANAGMENT------------//

        //Calls the stored SQL Function that returns all the existing Employees entities in the database.
        IEnumerable<Employee> GetAllEmployees();
        //Calls the stored SQL Function that returns the existing Employees entity in the database with the matching id.
        Employee GetEmployeeByIdCard(int idCard);
        //Calls the stored SQL Procedure that inserts, updates or deletes a Employees Entity in the database..
        void CreateUpdateDeleteEmployee(Employee employee, string statementType);


        //-----------GYM CONFIGURATIONS------------//

        //Calls the SQL Procedure that creates the asociation between spa treatments and the specified gym entity.
        void SetSpaTreatmentsToGym(IEnumerable<GymService> spaTreatments, int gymId);
        //Calls the SQL Procedure that creates the asociation between products and the specified gym entity.
        void SetProductsToGym(IEnumerable<Product> spaTreatments, int gymId);
        //Calls the SQL Procedure that creates the asociation between machines and the specified gym entity.
        void SetMachinesToGym(IEnumerable<ExcerciseMachine> machines, int gymId);
    
    }

}