namespace ClinicService.Models
{
    /// <summary>
    /// Модель представления питомца, зарегистрированного в клинике.
    /// Описывает основную информацию о питомце, принадлежащем определенному клиенту.
    /// </summary>
    public class Pet
    {
        /// <summary>
        /// Уникальный идентификатор питомца.
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
