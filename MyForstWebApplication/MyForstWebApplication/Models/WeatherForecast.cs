using System;

namespace MyForstWebApplication.Models
{
    // Класс, представляющий прогноз погоды
    public class WeatherForecast
    {
        // Дата прогноза
        public DateTime Date { get; set; }

        // Температура в градусах Цельсия
        public int TemperatureC { get; set; }

        // Температура в градусах Фаренгейта, вычисляемая из TemperatureC
        public int TemperatureF => 32 + (int)(TemperatureC * 9.0 / 5); // Оптимизированный метод для конвертации температуры
    }
}
