using ClinicService.Models;

namespace ClinicService.Services
{
    /// <summary>
    /// Интерфейс репозитория консультаций.
    /// Определяет контракты для работы с данными о консультациях.
    /// </summary>
    public interface IConsultationRepository : IRepository<Consultation, int>
    {
    }
}
