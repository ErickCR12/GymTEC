
using System;
using System.Collections.Generic;
using System.Data;
using GymTEC_API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GymTEC_API.Data
{
    public class SQLRepo : ISQLRepo
    {

        SqlConnection connection;
        
        public SQLRepo(IConfiguration config) 
        {
            
            var connectionString = config.GetValue<string>("SQL_uri");
            connection = new SqlConnection(connectionString);
        }

        public LoginProfile CheckCredentials(LoginProfile loginProfile)
        {
            Employee employee = GetEmployeeByIdCard(loginProfile.Username);
            loginProfile.UserType = (employee != null) ? GetPositionById(employee.idJobPosition).name:"Invalid";
            return loginProfile;
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
                gym.name = dataReader.GetValue(1).ToString();
                gym.capacity = Int32.Parse(dataReader.GetValue(2).ToString());
                gym.province = dataReader.GetValue(3).ToString();
                gym.canton = dataReader.GetValue(4).ToString();
                gym.district = dataReader.GetValue(5).ToString();
                gym.openingTime = Convert.ToDateTime(dataReader.GetValue(6).ToString());
                gym.closingTime = Convert.ToDateTime(dataReader.GetValue(7).ToString());
                gym.openingDate = Convert.ToDateTime(dataReader.GetValue(8).ToString());
                gym.spaState = Int32.Parse(dataReader.GetValue(9).ToString()) != 0; 
                gym.storeState = Int32.Parse(dataReader.GetValue(10).ToString()) != 0;
                gym.idAdmin = (dataReader.GetValue(11) == DBNull.Value) ? -1 : Int32.Parse(dataReader.GetValue(11).ToString());

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
                gym.name = dataReader.GetValue(1).ToString();
                gym.capacity = Int32.Parse(dataReader.GetValue(2).ToString());
                gym.province = dataReader.GetValue(3).ToString();
                gym.canton = dataReader.GetValue(4).ToString();
                gym.district = dataReader.GetValue(5).ToString();
                gym.openingTime = Convert.ToDateTime(dataReader.GetValue(6).ToString());
                gym.closingTime = Convert.ToDateTime(dataReader.GetValue(7).ToString());
                gym.openingDate = Convert.ToDateTime(dataReader.GetValue(8).ToString());
                gym.spaState = Int32.Parse(dataReader.GetValue(9).ToString()) != 0; 
                gym.storeState = Int32.Parse(dataReader.GetValue(10).ToString()) != 0;
                gym.idAdmin = (dataReader.GetValue(11) == DBNull.Value) ? -1 : Int32.Parse(dataReader.GetValue(11).ToString());
   
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

public IEnumerable<GymService> GetAllServices()
        {
            List<GymService> services = new List<GymService>();
            
            connection.Open();
            var sql = "SELECT * FROM dbo.GetAllServices()"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read()) //Loads all the atributes for each Gym entity
            {
                GymService service = new GymService();
                service.id = Int32.Parse(dataReader.GetValue(0).ToString());
                service.name = dataReader.GetValue(1).ToString();

                services.Add(service);
            }
            connection.Close();
            return services;
        }

        public GymService GetServiceById(int id)
        {
            GymService service = new GymService(); 
            connection.Open();
            var sql = "SELECT * FROM dbo.GetServiceById(@id)"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {
                service.id = Int32.Parse(dataReader.GetValue(0).ToString());
                service.name = dataReader.GetValue(1).ToString();

                connection.Close();
                return service;
            }
            connection.Close();
            return null;
        }

        public void CreateUpdateDeleteService(GymService service, string statementType)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("CreateUpdateDelete_Service", connection); //Stored Procedure that can insert, update or delete Gym entity
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", service.id);
            command.Parameters.AddWithValue("@nombre", service.name);
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

        public IEnumerable<PayrollGeneration> GetMonthlyPayroll(int gymId)
        {
            List<PayrollGeneration> payrolls = new List<PayrollGeneration>();
            
            connection.Open();
            var sql = "SELECT * FROM dbo.GetMonthlyPayroll()"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read()) //Loads all the atributes for each Payroll entity
            {
                PayrollGeneration payroll = new PayrollGeneration();
                payroll.idCard = Int32.Parse(dataReader.GetValue(0).ToString());
                payroll.name = dataReader.GetValue(1).ToString();
                payroll.last_name1 = dataReader.GetValue(2).ToString();
                payroll.last_name2 = dataReader.GetValue(3).ToString();
                payroll.classesHours = Int32.Parse(dataReader.GetValue(4).ToString());
                payroll.salary = Int32.Parse(dataReader.GetValue(4).ToString());

                payrolls.Add(payroll);
            }
            connection.Close();
            return payrolls;
        }

        public IEnumerable<PayrollGeneration> GetPayrollPerClass(int gymId)
        {
            List<PayrollGeneration> payrolls = new List<PayrollGeneration>();
            
            connection.Open();
            var sql = "SELECT * FROM dbo.GetPayrollPerClass()"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read()) //Loads all the atributes for each Payroll entity
            {
                PayrollGeneration payroll = new PayrollGeneration();
                payroll.idCard = Int32.Parse(dataReader.GetValue(0).ToString());
                payroll.name = dataReader.GetValue(1).ToString();
                payroll.last_name1 = dataReader.GetValue(2).ToString();
                payroll.last_name2 = dataReader.GetValue(3).ToString();
                payroll.classesHours = Int32.Parse(dataReader.GetValue(4).ToString());
                payroll.salary = Int32.Parse(dataReader.GetValue(5).ToString());
                payrolls.Add(payroll);
            }
            connection.Close();
            return payrolls;
        }

        public IEnumerable<PayrollGeneration> GetPayrollPerHours(int gymId)
        {
            List<PayrollGeneration> payrolls = new List<PayrollGeneration>();
            
            connection.Open();
            var sql = "SELECT * FROM dbo.GetPayrollPerHours()"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read()) //Loads all the atributes for each Payroll entity
            {
                PayrollGeneration payroll = new PayrollGeneration();
                payroll.idCard = Int32.Parse(dataReader.GetValue(0).ToString());
                payroll.name = dataReader.GetValue(1).ToString();
                payroll.last_name1 = dataReader.GetValue(2).ToString();
                payroll.last_name2 = dataReader.GetValue(3).ToString();
                payroll.classesHours = Int32.Parse(dataReader.GetValue(4).ToString());
                payroll.salary = Int32.Parse(dataReader.GetValue(5).ToString());
                payrolls.Add(payroll);
            }
            connection.Close();
            return payrolls;
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
                gymClass.idGym = Int32.Parse(dataReader.GetValue(1).ToString());
                gymClass.idService = Int32.Parse(dataReader.GetValue(2).ToString());
                gymClass.idInstructor = Int32.Parse(dataReader.GetValue(3).ToString());
                gymClass.startTime = Convert.ToDateTime(dataReader.GetValue(4).ToString());
                gymClass.endTime = Convert.ToDateTime(dataReader.GetValue(5).ToString());
                gymClass.date = Convert.ToDateTime(dataReader.GetValue(6).ToString());
                gymClass.capacity = Int32.Parse(dataReader.GetValue(7).ToString());
                gymClass.isGroup = Int32.Parse(dataReader.GetValue(8).ToString()) != 0;

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
                gymClass.idGym = Int32.Parse(dataReader.GetValue(1).ToString());
                gymClass.idService = Int32.Parse(dataReader.GetValue(2).ToString());
                gymClass.idInstructor = Int32.Parse(dataReader.GetValue(3).ToString());
                gymClass.startTime = Convert.ToDateTime(dataReader.GetValue(4).ToString());
                gymClass.endTime = Convert.ToDateTime(dataReader.GetValue(5).ToString());
                gymClass.date = Convert.ToDateTime(dataReader.GetValue(6).ToString());
                gymClass.capacity = Int32.Parse(dataReader.GetValue(7).ToString());
                gymClass.isGroup = Int32.Parse(dataReader.GetValue(8).ToString()) != 0;
                
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
            command.Parameters.AddWithValue("@id_sucursal", gymClass.idGym);
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

        public IEnumerable<GymClass> GetFilteredClasses(ClassFilter filters)
        {
            List<GymClass> gymClasses = new List<GymClass>();
            
            connection.Open();
            var sql = "SELECT * FROM dbo.GetFilteredClasses(@sucursalId, @servicioId, @fecha, @horaInicio, @horaFin)"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@sucursalId", filters.idGym);
            command.Parameters.AddWithValue("@servicioId", (filters.idService == -1) ? DBNull.Value: filters.idService);
            command.Parameters.AddWithValue("@fecha", (filters.date == null) ? DBNull.Value: filters.date);
            command.Parameters.AddWithValue("@horaInicio", (filters.startTime == null) ? DBNull.Value: filters.startTime);
            command.Parameters.AddWithValue("@horaFin", (filters.endTime == null) ? DBNull.Value: filters.endTime);

            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read()) //Loads all the atributes for each Gym entity
            {
                GymClass gymClass = new GymClass();
                gymClass.id = Int32.Parse(dataReader.GetValue(0).ToString());
                gymClass.idGym = Int32.Parse(dataReader.GetValue(1).ToString());
                gymClass.idService = Int32.Parse(dataReader.GetValue(2).ToString());
                gymClass.idInstructor = Int32.Parse(dataReader.GetValue(3).ToString());
                gymClass.serviceName = dataReader.GetValue(4).ToString();
                gymClass.date = Convert.ToDateTime(dataReader.GetValue(5).ToString());
                gymClass.startTime = Convert.ToDateTime(dataReader.GetValue(6).ToString());
                gymClass.endTime = Convert.ToDateTime(dataReader.GetValue(7).ToString());
                gymClass.instructorName = dataReader.GetValue(8).ToString();
                gymClass.availability = Int32.Parse(dataReader.GetValue(9).ToString());

                gymClasses.Add(gymClass);
            }
            connection.Close();
            return gymClasses;
        }

        public void RegisterToClass(Client client, int classId)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("RegisterClientToClass", connection); //Stored Procedure that can insert, update or delete Gym entity
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id_clase", classId);
            command.Parameters.AddWithValue("@id_cliente", client.Id);

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

        public IEnumerable<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            
            connection.Open();
            var sql = "SELECT * FROM dbo.GetAllProducts()"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read()) //Loads all the atributes for each Gym entity
            {
                Product product = new Product();
                product.barCode = Int32.Parse(dataReader.GetValue(0).ToString());
                product.name = dataReader.GetValue(1).ToString();
                product.description = dataReader.GetValue(2).ToString();
                product.price = Int32.Parse(dataReader.GetValue(3).ToString());

                products.Add(product);
            }
            connection.Close();
            return products;
        }

        public Product GetProductByBarCode(int barCode)
        {           
            Product product = new Product(); 
            connection.Open();
            var sql = "SELECT * FROM dbo.GetProductByBarCode(@barCode)"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@barCode", barCode);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {
                product.barCode = Int32.Parse(dataReader.GetValue(0).ToString());
                product.name = dataReader.GetValue(1).ToString();
                product.description = dataReader.GetValue(2).ToString();
                product.price = Int32.Parse(dataReader.GetValue(3).ToString());
                
                connection.Close();
                return product;
            }
            connection.Close();
            return null;
        }

        public void CreateUpdateDeleteProduct(Product product, string statementType)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("CreateUpdateDelete_Product", connection); //Stored Procedure that can insert, update or delete Gym entity
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@codigo_barras", product.barCode);
            command.Parameters.AddWithValue("@nombre", product.name);
            command.Parameters.AddWithValue("@descripcion", product.description);
            command.Parameters.AddWithValue("@costo", product.price);
            command.Parameters.AddWithValue("@StatementType", statementType);

            command.ExecuteNonQuery();

            connection.Close();

        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            
            connection.Open();
            var sql = "SELECT * FROM dbo.GetAllEmployees()"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read()) //Loads all the atributes for each Employee entity
            {
                Employee employee = new Employee();
                employee.idCard = Int32.Parse(dataReader.GetValue(0).ToString());
                employee.idGym = Int32.Parse(dataReader.GetValue(1).ToString());
                employee.idJobPosition = Int32.Parse(dataReader.GetValue(2).ToString());
                employee.idPayroll = Int32.Parse(dataReader.GetValue(3).ToString());
                employee.email = dataReader.GetValue(4).ToString();
                employee.password = dataReader.GetValue(5).ToString();
                employee.name = dataReader.GetValue(6).ToString();
                employee.last_name1 = dataReader.GetValue(7).ToString();
                employee.last_name2 = dataReader.GetValue(8).ToString();
                employee.province = dataReader.GetValue(9).ToString();
                employee.canton = dataReader.GetValue(10).ToString();
                employee.district = dataReader.GetValue(11).ToString();
                employee.salary = Int32.Parse(dataReader.GetValue(12).ToString());

                employees.Add(employee);
            }
            connection.Close();
            return employees;
        }

        public Employee GetEmployeeByIdCard(int idCard)
        {           
            Employee employee = new Employee(); 
            connection.Open();
            var sql = "SELECT * FROM dbo.GetEmployeeByIdCard(@idCard)"; //Stored Function
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@idCard", idCard);
            SqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {
                employee.idCard = Int32.Parse(dataReader.GetValue(0).ToString());
                employee.idGym = Int32.Parse(dataReader.GetValue(1).ToString());
                employee.idJobPosition = Int32.Parse(dataReader.GetValue(2).ToString());
                employee.idPayroll = Int32.Parse(dataReader.GetValue(3).ToString());
                employee.email = dataReader.GetValue(4).ToString();
                employee.password = dataReader.GetValue(5).ToString();
                employee.name = dataReader.GetValue(6).ToString();
                employee.last_name1 = dataReader.GetValue(7).ToString();
                employee.last_name2 = dataReader.GetValue(8).ToString();
                employee.province = dataReader.GetValue(9).ToString();
                employee.canton = dataReader.GetValue(10).ToString();
                employee.district = dataReader.GetValue(11).ToString();
                employee.salary = Int32.Parse(dataReader.GetValue(12).ToString());
                
                connection.Close();
                return employee;
            }
            connection.Close();
            return null;
        }

        public void CreateUpdateDeleteEmployee(Employee employee, string statementType)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("CreateUpdateDelete_Employee", connection); //Stored Procedure that can insert, update or delete Employee entity
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@numero_cedula", employee.idCard);
            command.Parameters.AddWithValue("@id_sucursal", employee.idGym);
            command.Parameters.AddWithValue("@id_puesto", employee.idJobPosition);
            command.Parameters.AddWithValue("@id_planilla", employee.idPayroll);
            command.Parameters.AddWithValue("@correo", employee.email);
            command.Parameters.AddWithValue("@contraseña", employee.password);
            command.Parameters.AddWithValue("@nombre", employee.name);
            command.Parameters.AddWithValue("@apellido1", employee.last_name1);
            command.Parameters.AddWithValue("@apellido2", employee.last_name2);
            command.Parameters.AddWithValue("@provincia", employee.province);
            command.Parameters.AddWithValue("@canton", employee.canton);
            command.Parameters.AddWithValue("@distrito", employee.district);
            command.Parameters.AddWithValue("@salario", employee.salary);
            command.Parameters.AddWithValue("@StatementType", statementType);

            command.ExecuteNonQuery();

            connection.Close();

        }

        public void SetSpaTreatmentToGym(GymService spaTreatment, int gymId)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SetSpaTreatmentsToGym", connection); //Stored Procedure that can insert, update or delete Gym entity
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id_sucursal", gymId);
            command.Parameters.AddWithValue("@id_tratamiento", spaTreatment.id);
            command.ExecuteNonQuery();
            command.Parameters.Clear();

            connection.Close();
        }

        public void SetProductToGym(Product product, int gymId)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SetProductsToGym", connection); //Stored Procedure that can insert, update or delete Gym entity
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id_sucursal", gymId);
            command.Parameters.AddWithValue("@codigo_producto", product.barCode);
            command.ExecuteNonQuery();
            command.Parameters.Clear();

            connection.Close();
        }

        public void SetMachineToGym(ExcerciseMachine machine, int gymId)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SetMachinesToGym", connection); //Stored Procedure that can insert, update or delete Gym entity
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id_sucursal", gymId);
            command.Parameters.AddWithValue("@numero_maquina", machine.serialNumber);
            command.ExecuteNonQuery();
            command.Parameters.Clear();

            connection.Close();
        }

        public void CopyGymWeek(GymWeek week, int gymId)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("CopyGymWeek", connection); //Stored Procedure that can insert, update or delete Gym entity
            command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@sucursal", gymId);
                command.Parameters.AddWithValue("@fechaInicioOriginal", week.startingDate);
                command.Parameters.AddWithValue("@fechaFinalOriginal", week.finishingDate);
                command.Parameters.AddWithValue("@fechaInicioNueva", week.startingDateToCopy);
                command.Parameters.AddWithValue("@fechaFinalNueva", week.finishingDateToCopy);
                command.ExecuteNonQuery();
                command.Parameters.Clear();

            connection.Close();
        }

        public void CopyGym(Gym originalGym, int newGymId)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("CopyGym", connection); //Stored Procedure that can insert, update or delete Gym entity
            command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@idSucursalOriginal", originalGym.id);
                command.Parameters.AddWithValue("@idSucursalNueva", newGymId);
                command.ExecuteNonQuery();
                command.Parameters.Clear();

            connection.Close();
        }

        public void AddAdmin(Employee employee, int gymId)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("AddAdmin", connection); //Stored Procedure that can insert, update or delete Gym entity
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id_empleado", employee.idCard);
            command.Parameters.AddWithValue("@id_sucursal", gymId);
            command.ExecuteNonQuery();
            command.Parameters.Clear();

            connection.Close();
        }
    }
}