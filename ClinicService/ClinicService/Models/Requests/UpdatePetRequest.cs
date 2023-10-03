namespace ClinicService.Models.Requests
{
    /// <summary>
    /// Модель запроса для обновления данных питомца.
    /// Используется при передаче обновленных данных о питомце в API.
    /// </summary>
    public class UpdatePetRequest
    {
        /// <summary>
        /// Идентификатор питомца, данные которого требуется обновить.
        /// </summary>
        public int PetId { get; set; }

        /// <summary>
        /// Идентификатор клиента, которому принадлежит питомец.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Имя питомца.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата рождения питомца.
        /// </summary>
        public DateTime Birthday { get; set; }
    }
}
