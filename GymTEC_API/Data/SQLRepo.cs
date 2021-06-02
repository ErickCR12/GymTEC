
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
    }
}