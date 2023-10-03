namespace ClinicService.Models.Requests
{
    /// <summary>
    /// Модель запроса для обновления данных клиента.
    /// Используется при передаче обновленных данных о клиенте в API.
    /// </summary>
    public class UpdateClientRequest
    {
        /// <summary>
        /// Идентификатор клиента, данные которого требуется обновить.
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
        /// Отчество клиента.
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Дата рождения клиента.
        /// </summary>
        public DateTime Birthday { get; set; }
    }
}
