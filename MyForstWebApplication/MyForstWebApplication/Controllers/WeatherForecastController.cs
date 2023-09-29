using Microsoft.AspNetCore.Mvc;
using MyForstWebApplication.Models;
using System;
using System.Collections.Generic;

namespace MyForstWebApplication.Controllers
{
    // Контроллер API для работы с прогнозами погоды
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        // Хранилище прогнозов погоды
        private readonly WeatherForecastHolder _weatherForecastHolder;

        // Конструктор для внедрения зависимостей
        public WeatherForecastController(WeatherForecastHolder weatherForecastHolder)
        {
            _weatherForecastHolder = weatherForecastHolder;
        }

        // Добавление прогноза погоды
        [HttpPost("add")]
        public IActionResult Add([FromQuery] DateTime date, [FromQuery] int temperatureC)
        {
            _weatherForecastHolder.Add(date, temperatureC);
            return Ok(); // Возврат успешного ответа
        }

        // Обновление прогноза погоды
        [HttpPut("update")]
        public IActionResult Update([FromQuery] DateTime date, [FromQuery] int temperatureC)
        {
            bool updated = _weatherForecastHolder.Update(date, temperatureC);
            return updated ? Ok() : NotFound(); // Возврат успешного ответа или ошибки 404
        }

        // Удаление прогноза погоды
        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime date)
        {
            bool deleted = _weatherForecastHolder.Delete(date);
            return deleted ? Ok() : NotFound(); // Возврат успешного ответа или ошибки 404
        }

        // Получение списка прогнозов погоды за определенный период
        [HttpGet("get")]
        public IActionResult Get([FromQuery] DateTime dateFrom, [FromQuery] DateTime dateTo)
        {
            List<WeatherForecast> list = _weatherForecastHolder.Get(dateFrom, dateTo);
            return Ok(list); // Возврат списка прогнозов погоды
        }
    }
}
