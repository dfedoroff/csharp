namespace ClinicService.Models.Requests
{
    /// <summary>
    /// Модель запроса для создания нового питомца.
    /// Используется при передаче данных о питомце в API для его создания.
    /// </summary>
    public class CreatePetRequest
    {
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
