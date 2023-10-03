namespace ClinicService.Models.Requests
{
    /// <summary>
    /// Модель запроса для создания новой консультации.
    /// Используется при передаче данных о консультации в API для её создания.
    /// </summary>
    public class CreateConsultationRequest
    {
        /// <summary>
        /// Идентификатор клиента, для которого создаётся консультация.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Идентификатор питомца, по поводу которого создаётся консультация.
        /// </summary>
        public int PetId { get; set; }

        /// <summary>
        /// Дата и время проведения консультации.
        /// </summary>
        public DateTime ConsultationDate { get; set; }

        /// <summary>
        /// Описание или причина консультации.
        /// </summary>
        public string Description { get; set; }
    }
}
