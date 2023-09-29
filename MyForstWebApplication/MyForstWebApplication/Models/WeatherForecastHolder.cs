using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace MyForstWebApplication.Models
{
    // Класс, представляющий хранилище прогнозов погоды
    public class WeatherForecastHolder
    {
        // Потокобезопасная коллекция для хранения прогнозов погоды
        private readonly ConcurrentBag<WeatherForecast> _values;

        // Конструктор для инициализации коллекции
        public WeatherForecastHolder()
        {
            _values = new ConcurrentBag<WeatherForecast>();
        }

        // Добавление нового прогноза погоды в хранилище
        public void Add(DateTime dateTime, int temperatureC)
        {
            WeatherForecast forecast = new WeatherForecast
            {
                TemperatureC = temperatureC,
                Date = dateTime
            };
            _values.Add(forecast);
        }

        // Обновление существующего прогноза погоды в хранилище
        public bool Update(DateTime date, int temperatureC)
        {
            var existingForecast = _values.FirstOrDefault(item => item.Date == date);
            if (existingForecast != null)
            {
                // На данный момент просто возвращаем true
                return true;
            }
            return false;
        }

        // Получение списка прогнозов погоды за определенный период
        public List<WeatherForecast> Get(DateTime dateFrom, DateTime dateTo)
        {
            return _values.Where(item => item.Date >= dateFrom && item.Date <= dateTo).ToList();
        }

        // Удаление прогноза погоды из хранилища
        public bool Delete(DateTime date)
        {
            var existingForecast = _values.FirstOrDefault(item => item.Date == date);
            if (existingForecast != null)
            {
                // На данный момент просто возвращаем true
                return true;
            }
            return false;
        }
    }
}
