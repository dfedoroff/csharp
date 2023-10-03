using ClinicService.Models;
using System.Data.SQLite;

namespace ClinicService.Services.Impl
{
    /// <summary>
    /// Реализация репозитория животных с использованием базы данных SQLite.
    /// Предоставляет методы для создания, обновления, удаления и извлечения данных о животных.
    /// </summary>
    public class PetRepository : IPetRepository
    {
        /// <summary>
        /// Строка подключения к базе данных SQLite.
        /// </summary>
        private const string connectionString = "Data Source = clinic.db; Version = 3; Pooling = true; Max Pool Size = 100;";

        /// <summary>
        /// Создает новую запись о животном в базе данных.
        /// </summary>
        /// <param name="item">Данные нового животного.</param>
        /// <returns>Количество созданных записей в базе данных (обычно 1).</returns>
        public int Create(Pet item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "INSERT INTO Pets(ClientId, Name, Birthday) VALUES(@ClientId, @Name, @Birthday)";
            command.Parameters.AddWithValue("@ClientId", item.ClientId);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Birthday", item.Birthday.Ticks);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        /// <summary>
        /// Обновляет запись о животном в базе данных на основе предоставленных данных.
        /// </summary>
        /// <param name="item">Данные для обновления.</param>
        /// <returns>Количество обновленных записей (обычно 1).</returns>
        public int Update(Pet item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "UPDATE pets SET ClientId = @ClientId, Name = @Name, Birthday = @Birthday WHERE PetId = @PetId";
            command.Parameters.AddWithValue("@PetId", item.PetId);
            command.Parameters.AddWithValue("@ClientId", item.ClientId);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Birthday", item.Birthday.Ticks);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        /// <summary>
        /// Удаляет запись о животном из базы данных.
        /// </summary>
        /// <param name="id">Идентификатор животного для удаления.</param>
        /// <returns>Количество удаленных записей (обычно 1).</returns>
        public int Delete(int id)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "DELETE FROM pets WHERE PetId = @PetId";
            command.Parameters.AddWithValue("@PetId", id);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        /// <summary>
        /// Извлекает все животных из базы данных.
        /// </summary>
        /// <returns>Список всех животных.</returns>
        public IList<Pet> GetAll()
        {
            List<Pet> list = new List<Pet>();
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Pets";
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Pet pet = new Pet();
                pet.PetId = reader.GetInt32(0);
                pet.ClientId = reader.GetInt32(1);
                pet.Name = reader.GetString(2);
                pet.Birthday = new DateTime(reader.GetInt64(3));

                list.Add(pet);
            }

            connection.Close();
            return list;
        }

        /// <summary>
        /// Извлекает данные о животном из базы данных по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор животного.</param>
        /// <returns>Данные о животном или null, если такое животное не найдено.</returns>
        public Pet GetById(int id)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Pets WHERE PetId = @PetId";
            command.Parameters.AddWithValue("@PetId", id);
            command.Prepare();
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.Read()) 
            {
                Pet pet = new Pet();
                pet.PetId = reader.GetInt32(0);
                pet.ClientId = reader.GetInt32(1);
                pet.Name = reader.GetString(2);
                pet.Birthday = new DateTime(reader.GetInt64(3));

                connection.Close();
                return pet;
            }
            else
            {
                connection.Close();
                return null;
            }
        }
    }
}
