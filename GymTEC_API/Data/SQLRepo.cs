
using System;
using System.Collections.Generic;
using System.Data;
using GymTEC_API.Models;
using Microsoft.Data.SqlClient;

namespace GymTEC_API.Data
{
    public class SQLRepo : ISQLRepo
    {

        SqlConnection connection;
        
        public SQLRepo() 
        {
            var connectionString = "Server=localhost;Initial Catalog=gymTEC_DB;User ID=GymTEC_API;Password=gymtec";
            connection = new SqlConnection(connectionString);
        }

        public IEnumerable<Gym> GetAllGyms()
        {
            List<Gym> gyms = new List<Gym>();
            
            connection.Open();
            var sql = "SELECT * FROM dbo.GetAllGyms()"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read()) //Loads all the atributes for each Gym entity
            {
                Gym gym = new Gym();
                gym.id = Int32.Parse(dataReader.GetValue(0).ToString());
                gym.idAdmin = Int32.Parse(dataReader.GetValue(1).ToString());
                gym.name = dataReader.GetValue(2).ToString();
                gym.capacity = Int32.Parse(dataReader.GetValue(3).ToString());
                gym.province = dataReader.GetValue(4).ToString();
                gym.canton = dataReader.GetValue(5).ToString();
                gym.district = dataReader.GetValue(6).ToString();
                gym.openingTime = Convert.ToDateTime(dataReader.GetValue(7).ToString());
                gym.closingTime = Convert.ToDateTime(dataReader.GetValue(8).ToString());
                gym.openingDate = Convert.ToDateTime(dataReader.GetValue(9).ToString());
                gym.spaState = Int32.Parse(dataReader.GetValue(10).ToString()) != 0; 
                gym.storeState = Int32.Parse(dataReader.GetValue(11).ToString()) != 0;

                gyms.Add(gym);
            }
            connection.Close();
            return gyms;
        }

        public Gym GetGymById(int id)
        {           
            Gym gym = new Gym(); 
            connection.Open();
            var sql = "SELECT * FROM dbo.GetGymById(@id)"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {
                gym.id = Int32.Parse(dataReader.GetValue(0).ToString());
                gym.idAdmin = Int32.Parse(dataReader.GetValue(1).ToString());
                gym.name = dataReader.GetValue(2).ToString();
                gym.capacity = Int32.Parse(dataReader.GetValue(3).ToString());
                gym.province = dataReader.GetValue(4).ToString();
                gym.canton = dataReader.GetValue(5).ToString();
                gym.district = dataReader.GetValue(6).ToString();
                gym.openingTime = Convert.ToDateTime(dataReader.GetValue(7).ToString());
                gym.closingTime = Convert.ToDateTime(dataReader.GetValue(8).ToString());
                gym.openingDate = Convert.ToDateTime(dataReader.GetValue(9).ToString());
                gym.spaState = Int32.Parse(dataReader.GetValue(10).ToString()) != 0; 
                gym.storeState = Int32.Parse(dataReader.GetValue(11).ToString()) != 0;
                
                connection.Close();
                return gym;
            }
            connection.Close();
            return null;
        }

        public void CreateUpdateDeleteGym(Gym gym, string statementType)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("CreateUpdateDelete_Gym", connection); //Stored Procedure that can insert, update or delete Gym entity
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", gym.id);
            command.Parameters.AddWithValue("@id_administrador", gym.idAdmin);
            command.Parameters.AddWithValue("@nombre", gym.name);
            command.Parameters.AddWithValue("@capacidad", gym.capacity);
            command.Parameters.AddWithValue("@provincia", gym.province);
            command.Parameters.AddWithValue("@canton", gym.canton);
            command.Parameters.AddWithValue("@distrito", gym.district);
            command.Parameters.AddWithValue("@hora_apertura", gym.openingTime);
            command.Parameters.AddWithValue("@hora_cierre", gym.closingTime);
            command.Parameters.AddWithValue("@fecha_apertura", gym.openingDate);
            command.Parameters.AddWithValue("@estado_spa", gym.spaState);
            command.Parameters.AddWithValue("@estado_tienda", gym.storeState);
            command.Parameters.AddWithValue("@StatementType", statementType);

            command.ExecuteNonQuery();

            connection.Close();

        }

        public IEnumerable<GymService> GetAllSpaTreatments()
        {
            List<GymService> spaTreatments = new List<GymService>();
            
            connection.Open();
            var sql = "SELECT * FROM dbo.GetAllSpaTreatments()"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read()) //Loads all the atributes for each Gym entity
            {
                GymService treatment = new GymService();
                treatment.id = Int32.Parse(dataReader.GetValue(0).ToString());
                treatment.name = dataReader.GetValue(1).ToString();

                spaTreatments.Add(treatment);
            }
            connection.Close();
            return spaTreatments;
        }

        public GymService GetSpaTreatmentById(int id)
        {
            GymService treatment = new GymService(); 
            connection.Open();
            var sql = "SELECT * FROM dbo.GetSpaTreatmentById(@id)"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {
                treatment.id = Int32.Parse(dataReader.GetValue(0).ToString());
                treatment.name = dataReader.GetValue(1).ToString();

                connection.Close();
                return treatment;
            }
            connection.Close();
            return null;
        }

        public void CreateUpdateDeleteSpaTreatment(GymService spaTreatment, string statementType)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("CreateUpdateDelete_SpaTreatment", connection); //Stored Procedure that can insert, update or delete Gym entity
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", spaTreatment.id);
            command.Parameters.AddWithValue("@nombre", spaTreatment.name);
            command.Parameters.AddWithValue("@StatementType", statementType);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public IEnumerable<Payroll> GetAllPayrolls()
        {
            List<Payroll> payrolls = new List<Payroll>();
            
            connection.Open();
            var sql = "SELECT * FROM dbo.GetAllPayrolls()"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read()) //Loads all the atributes for each Payroll entity
            {
                Payroll payroll = new Payroll();
                payroll.id = Int32.Parse(dataReader.GetValue(0).ToString());
                payroll.description = dataReader.GetValue(1).ToString();
                payroll.hourlyPay = Int32.Parse(dataReader.GetValue(2).ToString());
                payroll.monthlyPay = Int32.Parse(dataReader.GetValue(3).ToString());
                payroll.payPerClass = Int32.Parse(dataReader.GetValue(4).ToString());

                payrolls.Add(payroll);
            }
            connection.Close();
            return payrolls;
        }

        public Payroll GetPayrollById(int id)
        {
            Payroll payroll = new Payroll(); 
            connection.Open();
            var sql = "SELECT * FROM dbo.GetPayrollById(@id)"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {
                payroll.id = Int32.Parse(dataReader.GetValue(0).ToString());
                payroll.description = dataReader.GetValue(1).ToString();
                payroll.hourlyPay = Int32.Parse(dataReader.GetValue(2).ToString());
                payroll.monthlyPay = Int32.Parse(dataReader.GetValue(3).ToString());
                payroll.payPerClass = Int32.Parse(dataReader.GetValue(4).ToString());

                connection.Close();
                return payroll;
            }
            connection.Close();
            return null;
        }

        public void CreateUpdateDeletePayroll(Payroll payroll, string statementType)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("CreateUpdateDelete_Payroll", connection); //Stored Procedure that can insert, update or delete Gym entity
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", payroll.id);
            command.Parameters.AddWithValue("@descripcion", payroll.description);
            command.Parameters.AddWithValue("@pago_horas", payroll.hourlyPay);
            command.Parameters.AddWithValue("@pago_mensual", payroll.monthlyPay);
            command.Parameters.AddWithValue("@pago_clase", payroll.payPerClass);
            command.Parameters.AddWithValue("@StatementType", statementType);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public IEnumerable<GymService> GetAllPositions()
        {
            List<GymService> positions = new List<GymService>();
            
            connection.Open();
            var sql = "SELECT * FROM dbo.GetAllPositions()"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read()) //Loads all the atributes for each Gym entity
            {
                GymService position = new GymService();
                position.id = Int32.Parse(dataReader.GetValue(0).ToString());
                position.name = dataReader.GetValue(1).ToString();

                positions.Add(position);
            }
            connection.Close();
            return positions;
        }

        public GymService GetPositionById(int id)
        {
            GymService position = new GymService(); 
            connection.Open();
            var sql = "SELECT * FROM dbo.GetPositionById(@id)"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {
                position.id = Int32.Parse(dataReader.GetValue(0).ToString());
                position.name = dataReader.GetValue(1).ToString();

                connection.Close();
                return position;
            }
            connection.Close();
            return null;
        }

        public void CreateUpdateDeletePosition(GymService position, string statementType)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("CreateUpdateDelete_Position", connection); //Stored Procedure that can insert, update or delete Gym entity
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", position.id);
            command.Parameters.AddWithValue("@nombre", position.name);
            command.Parameters.AddWithValue("@StatementType", statementType);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public IEnumerable<GymClass> GetAllClasses()
        {
            List<GymClass> gymClasses = new List<GymClass>();
            
            connection.Open();
            var sql = "SELECT * FROM dbo.GetAllClasses()"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read()) //Loads all the atributes for each Gym entity
            {
                GymClass gymClass = new GymClass();
                gymClass.id = Int32.Parse(dataReader.GetValue(0).ToString());
                gymClass.idService = Int32.Parse(dataReader.GetValue(1).ToString());
                gymClass.idInstructor = Int32.Parse(dataReader.GetValue(2).ToString());
                gymClass.startTime = Convert.ToDateTime(dataReader.GetValue(3).ToString());
                gymClass.endTime = Convert.ToDateTime(dataReader.GetValue(4).ToString());
                gymClass.date = Convert.ToDateTime(dataReader.GetValue(5).ToString());
                gymClass.capacity = Int32.Parse(dataReader.GetValue(6).ToString());
                gymClass.isGroup = Int32.Parse(dataReader.GetValue(7).ToString()) != 0;

                gymClasses.Add(gymClass);
            }
            connection.Close();
            return gymClasses;
        }

        public GymClass GetClassById(int id)
        {           
            GymClass gymClass = new GymClass(); 
            connection.Open();
            var sql = "SELECT * FROM dbo.GetClassById(@id)"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {
                gymClass.id = Int32.Parse(dataReader.GetValue(0).ToString());
                gymClass.idService = Int32.Parse(dataReader.GetValue(1).ToString());
                gymClass.idInstructor = Int32.Parse(dataReader.GetValue(2).ToString());
                gymClass.startTime = Convert.ToDateTime(dataReader.GetValue(3).ToString());
                gymClass.endTime = Convert.ToDateTime(dataReader.GetValue(4).ToString());
                gymClass.date = Convert.ToDateTime(dataReader.GetValue(5).ToString());
                gymClass.capacity = Int32.Parse(dataReader.GetValue(6).ToString());
                gymClass.isGroup = Int32.Parse(dataReader.GetValue(7).ToString()) != 0;
                
                connection.Close();
                return gymClass;
            }
            connection.Close();
            return null;
        }

        public void CreateUpdateDeleteClass(GymClass gymClass, string statementType)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("CreateUpdateDelete_Class", connection); //Stored Procedure that can insert, update or delete Gym entity
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", gymClass.id);
            command.Parameters.AddWithValue("@id_servicio", gymClass.idService);
            command.Parameters.AddWithValue("@cedula_instructor", gymClass.idInstructor);
            command.Parameters.AddWithValue("@fecha", gymClass.date);
            command.Parameters.AddWithValue("@hora_inicio", gymClass.startTime);
            command.Parameters.AddWithValue("@hora_fin", gymClass.endTime);
            command.Parameters.AddWithValue("@capacidad", gymClass.capacity);
            command.Parameters.AddWithValue("@es_grupal", gymClass.isGroup);
            command.Parameters.AddWithValue("@StatementType", statementType);

            command.ExecuteNonQuery();

            connection.Close();

        }

        public IEnumerable<GymService> GetAllEquipmentTypes()
        {
            List<GymService> equipmentTypes = new List<GymService>();
            
            connection.Open();
            var sql = "SELECT * FROM dbo.GetAllEquipmentTypes()"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read()) //Loads all the atributes for each Gym entity
            {
                GymService equipmentType = new GymService();
                equipmentType.id = Int32.Parse(dataReader.GetValue(0).ToString());
                equipmentType.name = dataReader.GetValue(1).ToString();

                equipmentTypes.Add(equipmentType);
            }
            connection.Close();
            return equipmentTypes;
        }

        public GymService GetEquipmentTypeById(int id)
        {
            GymService equipmentType = new GymService(); 
            connection.Open();
            var sql = "SELECT * FROM dbo.GetEquipmentTypeById(@id)"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {
                equipmentType.id = Int32.Parse(dataReader.GetValue(0).ToString());
                equipmentType.name = dataReader.GetValue(1).ToString();

                connection.Close();
                return equipmentType;
            }
            connection.Close();
            return null;
        }

        public void CreateUpdateDeleteEquipmentType(GymService equipmentType, string statementType)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("CreateUpdateDelete_EquipmentType", connection); //Stored Procedure that can insert, update or delete Gym entity
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", equipmentType.id);
            command.Parameters.AddWithValue("@nombre", equipmentType.name);
            command.Parameters.AddWithValue("@StatementType", statementType);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public IEnumerable<ExcerciseMachine> GetAllMachines()
        {
            List<ExcerciseMachine> machines = new List<ExcerciseMachine>();
            
            connection.Open();
            var sql = "SELECT * FROM dbo.GetAllMachines()"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read()) //Loads all the atributes for each Gym entity
            {
                ExcerciseMachine machine = new ExcerciseMachine();
                machine.serialNumber = Int32.Parse(dataReader.GetValue(0).ToString());
                machine.idEquipment = Int32.Parse(dataReader.GetValue(1).ToString());
                machine.brand = dataReader.GetValue(2).ToString();
                machine.price = Int32.Parse(dataReader.GetValue(3).ToString());

                machines.Add(machine);
            }
            connection.Close();
            return machines;
        }

        public ExcerciseMachine GetMachineBySerialNumber(int serialNumber)
        {           
            ExcerciseMachine machine = new ExcerciseMachine(); 
            connection.Open();
            var sql = "SELECT * FROM dbo.GetMachineBySerialNumber(@serialNumber)"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@serialNumber", serialNumber);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {
                machine.serialNumber = Int32.Parse(dataReader.GetValue(0).ToString());
                machine.idEquipment = Int32.Parse(dataReader.GetValue(1).ToString());
                machine.brand = dataReader.GetValue(2).ToString();
                machine.price = Int32.Parse(dataReader.GetValue(3).ToString());
                
                connection.Close();
                return machine;
            }
            connection.Close();
            return null;
        }

        public void CreateUpdateDeleteMachine(ExcerciseMachine machine, string statementType)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("CreateUpdateDelete_Machine", connection); //Stored Procedure that can insert, update or delete Gym entity
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@numero_serie", machine.serialNumber);
            command.Parameters.AddWithValue("@tipo_equipo", machine.idEquipment);
            command.Parameters.AddWithValue("@marca", machine.brand);
            command.Parameters.AddWithValue("@costo", machine.price);
            command.Parameters.AddWithValue("@StatementType", statementType);

            command.ExecuteNonQuery();

            connection.Close();

        }
    }
}