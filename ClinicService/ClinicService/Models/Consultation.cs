namespace ClinicService.Models
{
    /// <summary>
    /// Модель представления консультации в клинике.
    /// Описывает основную информацию о консультации, связанной с питомцем и клиентом.
    /// </summary>
    public class Consultation
    {
        /// <summary>
        /// Уникальный идентификатор консультации.
        /// </summary>
        public int ConsultationId { get; set; }

        /// <summary>
        /// Идентификатор клиента, для которого проводилась консультация.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Идентификатор питомца, по поводу которого проводилась консультация.
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
