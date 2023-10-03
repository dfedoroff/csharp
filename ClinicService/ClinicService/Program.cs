using ClinicService.Services;
using ClinicService.Services.Impl;
using System.Data.SQLite;

namespace ClinicService
{
    /// <summary>
    /// Основной класс приложения.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Основная точка входа в приложение.
        /// </summary>
        public static void Main(string[] args)
        {
            // Настройка и инициализация базы данных SQLite.
            // ConfigureSqliteConnection();

            // Создание и настройка билдера веб-приложения.
            var builder = WebApplication.CreateBuilder(args);

            // Регистрация сервисов-репозиториев в контейнере зависимостей.
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IConsultationRepository, ConsultationRepository>();
            builder.Services.AddScoped<IPetRepository, PetRepository>();

            // Добавление и настройка контроллеров.
            builder.Services.AddControllers();
            
            // Настройка и добавление Swagger для API документации.
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Создание веб-приложения.
            var app = builder.Build();

            // Конфигурация HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // В режиме разработки используем Swagger для документации API.
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Использование авторизации.
            app.UseAuthorization();

            // Маппинг контроллеров.
            app.MapControllers();

            // Запуск веб-приложения.
            app.Run();
        }

        /// <summary>
        /// Настройка и инициализация SQLite соединения.
        /// </summary>
        private static void ConfigureSqliteConnection()
        {
            string connectionString = "Data Source = clinic.db; Version = 3; Pooling = true; Max Pool Size = 100;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            PrepareSchema(connection);
        }

        /// <summary>
        /// Подготовка схемы базы данных. Создание или обновление таблиц.
        /// </summary>
        /// <param name="connection">Соединение с базой данных.</param>
        private static void PrepareSchema(SQLiteConnection connection)
        {
            SQLiteCommand command = new SQLiteCommand(connection);

            // Удаление существующих таблиц (если они есть).
            command.CommandText = "DROP TABLE IF EXISTS Consultations";
            command.ExecuteNonQuery();
            command.CommandText = "DROP TABLE IF EXISTS Pets";
            command.ExecuteNonQuery();
            command.CommandText = "DROP TABLE IF EXISTS Clients";
            command.ExecuteNonQuery();

            // Создание новых таблиц.
            command.CommandText =
                    @"CREATE TABLE Clients(
                    ClientId INTEGER PRIMARY KEY,
                    Document TEXT,
                    SurName TEXT,
                    FirstName TEXT,
                    Patronymic TEXT,
                    Birthday INTEGER)";
            command.ExecuteNonQuery();
            command.CommandText =
                    @"CREATE TABLE Pets(
                    PetId INTEGER PRIMARY KEY,
                    ClientId INTEGER,
                    Name TEXT,
                    Birthday INTEGER)";
            command.ExecuteNonQuery();
            command.CommandText =
                    @"CREATE TABLE Consultations(
                    ConsultationId INTEGER PRIMARY KEY,
                    ClientId INTEGER,
                    PetId INTEGER,
                    ConsultationDate INTEGER,
                    Description TEXT)";
            command.ExecuteNonQuery();
        }
    }
}
