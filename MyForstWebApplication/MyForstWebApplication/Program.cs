using MyForstWebApplication.Models; // Используется для доступа к классам моделей приложения

namespace MyForstWebApplication
{
    public class Program
    {
        // Точка входа в приложение
        public static void Main(string[] args)
        {
            // Создание и конфигурация веб-приложения
            var builder = WebApplication.CreateBuilder(args);

            // Добавление служб к контейнеру
            builder.Services.AddControllers(); // Регистрация контроллеров
            builder.Services.AddSingleton<WeatherForecastHolder>(); // Регистрация хранилища прогнозов погоды

            // Конфигурация Swagger для документации API
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Построение веб-приложения
            var app = builder.Build();

            // Настройка конвейера запросов HTTP
            if (app.Environment.IsDevelopment())
            {
                // Включение Swagger в режиме разработки
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization(); // Применение службы авторизации

            app.MapControllers(); // Настройка маршрутов контроллеров

            app.Run(); // Запуск приложения
        }
    }
}
