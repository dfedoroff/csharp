using ClinicService.Models;
using System.Data.SQLite;

namespace ClinicService.Services.Impl
{
    /// <summary>
    /// Реализация репозитория консультаций с использованием базы данных SQLite.
    /// Предоставляет методы для создания, обновления, удаления и извлечения данных о консультациях.
    /// </summary>
    public class ConsultationRepository : IConsultationRepository
    {
        /// <summary>
        /// Строка подключения к базе данных SQLite.
        /// </summary>
        private const string connectionString = "Data Source = clinic.db; Version = 3; Pooling = true; Max Pool Size = 100;";

        /// <summary>
        /// Создает новую запись консультации в базе данных.
        /// </summary>
        /// <param name="item">Данные новой консультации.</param>
        /// <returns>Количество созданных записей в базе данных (обычно 1).</returns>
        public int Create(Consultation item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "INSERT INTO Consultations(ClientId, PetId, ConsultationDate, Description) VALUES(@ClientId, @PetId, @ConsultationDate, @Description)";
            command.Parameters.AddWithValue("@ClientId", item.ClientId);
            command.Parameters.AddWithValue("@PetId", item.PetId);
            command.Parameters.AddWithValue("@ConsultationDate", item.ConsultationDate.Ticks);
            command.Parameters.AddWithValue("@Description", item.Description);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        /// <summary>
        /// Обновляет запись о консультации в базе данных на основе предоставленных данных.
        /// </summary>
        /// <param name="item">Данные для обновления.</param>
        /// <returns>Количество обновленных записей (обычно 1).</returns>
        public int Update(Consultation item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "UPDATE consultations SET ClientId = @ClientId, PetId = @PetId, ConsultationDate = @ConsultationDate, Description = @Description WHERE ConsultationId = @ConsultationId";
            command.Parameters.AddWithValue("@ConsultationId", item.ConsultationId);
            command.Parameters.AddWithValue("@ClientId", item.ClientId);
            command.Parameters.AddWithValue("@PetId", item.PetId);
            command.Parameters.AddWithValue("@ConsultationDate", item.ConsultationDate.Ticks);
            command.Parameters.AddWithValue("@Description", item.Description);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        /// <summary>
        /// Удаляет запись о консультации из базы данных.
        /// </summary>
        /// <param name="id">Идентификатор консультации для удаления.</param>
        /// <returns>Количество удаленных записей (обычно 1).</returns>
        public int Delete(int id)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "DELETE FROM consultations WHERE ConsultationId = @ConsultationId";
            command.Parameters.AddWithValue("@ConsultationId", id);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        /// <summary>
        /// Извлекает все консультации из базы данных.
        /// </summary>
        /// <returns>Список всех консультаций.</returns>
        public IList<Consultation> GetAll()
        {
            List<Consultation> list = new List<Consultation>();
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Consultations";
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Consultation consultation = new Consultation();
                consultation.ConsultationId = reader.GetInt32(0);
                consultation.ClientId = reader.GetInt32(1);
                consultation.PetId = reader.GetInt32(2);
                consultation.ConsultationDate = new DateTime(reader.GetInt64(3));
                consultation.Description = reader.GetString(4);

                list.Add(consultation);
            }
            connection.Close();
            return list;
        }

        /// <summary>
        /// Извлекает данные о консультации из базы данных по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор консультации.</param>
        /// <returns>Данные о консультации или null, если такая консультация не найдена.</returns>
        public Consultation GetById(int id)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Consultations WHERE ConsultationId = @ConsultationId";
            command.Parameters.AddWithValue("@ConsultationId", id);
            command.Prepare();
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.Read()) 
            {
                Consultation consultation = new Consultation();
                consultation.ConsultationId = reader.GetInt32(0);
                consultation.ClientId = reader.GetInt32(1);
                consultation.PetId = reader.GetInt32(2);
                consultation.ConsultationDate = new DateTime(reader.GetInt64(3));
                consultation.Description = reader.GetString(4);

                connection.Close();
                return consultation;
            }
            else
            {
                connection.Close();
                return null;
            }
        }
    }
}
