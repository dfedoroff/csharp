using ClinicService.Models;

namespace ClinicService.Services
{
    /// <summary>
    /// Интерфейс репозитория животных.
    /// Определяет контракты для работы с данными о животных.
    /// </summary>
    public interface IPetRepository : IRepository<Pet, int>
    {
    }
}
