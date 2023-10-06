using ClinicService.Models;
using Microsoft.Data.Sqlite;

namespace ClinicService.Services.Impl
{
    public class ConsultationRepository : IConsultationRepository
    {

        private const string connectionString = "Data Source = clinic.db;";


        public int Create(Consultation item)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO consultations(ClientId, PetId, ConsultationDate, Description) VALUES(@ClientId, @PetId, @ConsultationDate, @Description)";
                command.Parameters.AddWithValue("@ClientId", item.ClientId);
                command.Parameters.AddWithValue("@PetId", item.PetId);
                command.Parameters.AddWithValue("@ConsultationDate", item.ConsultationDate.Ticks);
                command.Parameters.AddWithValue("@Description", item.Description);
                command.Prepare();
                return command.ExecuteNonQuery();
            }
        }

        public int Update(Consultation item)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE consultations SET ClientId = @ClientId, PetId = @PetId, ConsultationDate = @ConsultationDate, Description = @Description WHERE ConsultationId=@ConsultationId";
                command.Parameters.AddWithValue("@ConsultationId", item.ConsultationId);
                command.Parameters.AddWithValue("@ClientId", item.ClientId);
                command.Parameters.AddWithValue("@PetId", item.PetId);
                command.Parameters.AddWithValue("@ConsultationDate", item.ConsultationDate.Ticks);
                command.Parameters.AddWithValue("@Description", item.Description);
                command.Prepare();
                return command.ExecuteNonQuery();
            }
        }

        public int Delete(int id)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM consultations WHERE ConsultationId=@ConsultationId";
                command.Parameters.AddWithValue("@ConsultationId", id);
                command.Prepare();
                return command.ExecuteNonQuery();
            }
        }

        public List<Consultation> GetAll()
        {
            List<Consultation> list = new List<Consultation>();
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM consultations";
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Consultation consultation = new Consultation
                    {
                        ConsultationId = reader.GetInt32(0),
                        ClientId = reader.GetInt32(1),
                        PetId = reader.GetInt32(2),
                        ConsultationDate = new DateTime(reader.GetInt64(3)),
                        Description = reader.GetString(4)
                    };

                    list.Add(consultation);
                }
            }
            return list;
        }

        public Consultation GetById(int id)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM consultations WHERE ConsultationId=@ConsultationId";
                command.Parameters.AddWithValue("@ConsultationId", id);
                command.Prepare();
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Consultation consultation = new Consultation
                    {
                        ConsultationId = reader.GetInt32(0),
                        ClientId = reader.GetInt32(1),
                        PetId = reader.GetInt32(2),
                        ConsultationDate = new DateTime(reader.GetInt64(3)),
                        Description = reader.GetString(4)
                    };
                    return consultation;
                }
            }
            return null;
        }
    }
}
