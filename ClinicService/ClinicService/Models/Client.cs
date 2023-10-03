namespace ClinicService.Models
{
    /// <summary>
    /// Модель представления клиента клиники.
    /// Описывает основную информацию о клиенте.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Уникальный идентификатор клиента.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Документ клиента (например, паспортные данные).
        /// </summary>
        public string Document { get; set; }

        /// <summary>
        /// Фамилия клиента.
        /// </summary>
        public string SurName { get; set; }

        /// <summary>
        /// Имя клиента.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество клиента. Может быть не указано.
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Дата рождения клиента.
        /// </summary>
        public DateTime Birthday { get; set; }
    }
}
