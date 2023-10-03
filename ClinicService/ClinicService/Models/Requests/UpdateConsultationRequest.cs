namespace ClinicService.Models.Requests
{
    /// <summary>
    /// Модель запроса для обновления данных консультации.
    /// Используется при передаче обновленных данных о консультации в API.
    /// </summary>
    public class UpdateConsultationRequest
    {
        /// <summary>
        /// Идентификатор консультации, данные которой требуется обновить.
        /// </summary>
        public int ConsultationId { get; set; }

        /// <summary>
        /// Идентификатор клиента, для которого проводится консультация.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Идентификатор питомца, по поводу которого проводится консультация.
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
