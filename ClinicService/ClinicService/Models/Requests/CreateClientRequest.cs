namespace ClinicService.Models.Requests
{
    /// <summary>
    /// Модель запроса для создания нового клиента.
    /// Используется при передаче данных о клиенте в API для его создания.
    /// </summary>
    public class CreateClientRequest
    {
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
        /// Отчество клиента.
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Дата рождения клиента.
        /// </summary>
        public DateTime Birthday { get; set; }
    }
}
