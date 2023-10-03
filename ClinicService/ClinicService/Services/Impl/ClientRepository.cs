using ClinicService.Models;
using System.Data.SQLite;

namespace ClinicService.Services.Impl
{
    /// <summary>
    /// Реализация репозитория клиентов с использованием базы данных SQLite.
    /// Предоставляет методы для создания, обновления, удаления и извлечения данных о клиентах.
    /// </summary>
    public class ClientRepository : IClientRepository
    {
        /// <summary>
        /// Строка подключения к базе данных SQLite.
        /// </summary>
        private const string connectionString = "Data Source = clinic.db; Version = 3; Pooling = true; Max Pool Size = 100;";

        /// <summary>
        /// Создает новую запись клиента в базе данных.
        /// </summary>
        /// <param name="item">Данные нового клиента.</param>
        /// <returns>Количество созданных записей в базе данных (обычно 1).</returns>
        public int Create(Client item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "INSERT INTO Clients(Document, SurName, FirstName, Patronymic, Birthday) VALUES(@Document, @SurName, @FirstName, @Patronymic, @Birthday)";
            command.Parameters.AddWithValue("@Document", item.Document);
            command.Parameters.AddWithValue("@SurName", item.SurName);
            command.Parameters.AddWithValue("@FirstName", item.FirstName);
            command.Parameters.AddWithValue("@Patronymic", item.Patronymic);
            command.Parameters.AddWithValue("@Birthday", item.Birthday.Ticks);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        /// <summary>
        /// Обновляет запись о клиенте в базе данных на основе предоставленных данных.
        /// </summary>
        /// <param name="item">Данные для обновления.</param>
        /// <returns>Количество обновленных записей (обычно 1).</returns>
        public int Update(Client item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "UPDATE clients SET Document = @Document, FirstName = @FirstName, SurName = @SurName, Patronymic = @Patronymic, Birthday = @Birthday WHERE ClientId = @ClientId";
            command.Parameters.AddWithValue("@ClientId", item.ClientId);
            command.Parameters.AddWithValue("@Document", item.Document);
            command.Parameters.AddWithValue("@SurName", item.SurName);
            command.Parameters.AddWithValue("@FirstName", item.FirstName);
            command.Parameters.AddWithValue("@Patronymic", item.Patronymic);
            command.Parameters.AddWithValue("@Birthday", item.Birthday.Ticks);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        /// <summary>
        /// Удаляет запись о клиенте из базы данных.
        /// </summary>
        /// <param name="id">Идентификатор клиента для удаления.</param>
        /// <returns>Количество удаленных записей (обычно 1).</returns>
        public int Delete(int id)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "DELETE FROM clients WHERE ClientId=@ClientId";
            command.Parameters.AddWithValue("@ClientId", id);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        /// <summary>
        /// Извлекает всех клиентов из базы данных.
        /// </summary>
        /// <returns>Список всех клиентов.</returns>
        public IList<Client> GetAll()
        {
            List<Client> list = new List<Client>();
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Clients";
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Client client = new Client();
                client.ClientId = reader.GetInt32(0);
                client.Document = reader.GetString(1);
                client.SurName = reader.GetString(2);
                client.FirstName = reader.GetString(3);
                client.Patronymic = reader.GetString(4);
                client.Birthday = new DateTime(reader.GetInt64(5));

                list.Add(client);
            }

            connection.Close();
            return list;
        }

        /// <summary>
        /// Извлекает данные о клиенте из базы данных по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор клиента.</param>
        /// <returns>Данные о клиенте или null, если такой клиент не найден.</returns>
        public Client GetById(int id)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Clients WHERE ClientId=@ClientId";
            command.Parameters.AddWithValue("@ClientId", id);
            command.Prepare();
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.Read()) 
            {
                Client client = new Client();
                client.ClientId = reader.GetInt32(0);
                client.Document = reader.GetString(1);
                client.SurName = reader.GetString(2);
                client.FirstName = reader.GetString(3);
                client.Patronymic = reader.GetString(4);
                client.Birthday = new DateTime(reader.GetInt64(5));

                connection.Close();
                return client;
            }
            else
            {
                connection.Close();
                return null;
            }
        }
    }
}
